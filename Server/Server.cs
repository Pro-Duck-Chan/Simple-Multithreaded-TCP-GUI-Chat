using Networking.Data;
using Networking.NetworkLib;
using Networking.Server.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Networking.Server //creats a namespace so we can use any name for the call we want and so it is easy to access form other scripts
{
    [System.Serializable]
    public class Server //creats a class
    {
        static ServerWindow serverWindow; //UI
        static Socket listenerSocket; //creats a Socket so we can listen on it
        static IPEndPoint serverIP; //creats a IPEndPoint so we can store server ip in it
        static Thread listenThread; //creats thread
        public static Thread removeClientThread; //creats thread
        public static Thread mainThread; //creats thread
        public static XmlDocument managedClients;
        public static bool isDataTableUpdating;

        public static List<ClientData> clients; //creats a list so we can store all the clients in it
        public static string port; //creats a string so we can store the port number in it
        public static bool started; //creats a bool so we know if the server is started

        public static Color colorSystem = Color.Green;
        public static Color colorAlert = Color.Red;
        public static Color colorConnect = Color.DarkGreen;
        public static Color colorDisconnect = Color.Orange;
        public static Color colorChat = Color.DarkBlue;
        public static Color colorSpecificChat = Color.Purple;
        public static XDocument managedClientsXML; //this might not work

        [STAThread]
        static void Main() //entry point function of the program
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serverWindow = new ServerWindow());
        }

        public static void StartServer() //run to start server
        {
            CheckXML();
            mainThread = Thread.CurrentThread;

            if (started)
                StopServer();

            try
            {
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //sets listenerSocket with AddressFamily, SocketType, ProtocolType
                serverIP = new IPEndPoint(IPAddress.Parse(NetworkFunctions.GetIP4Address()), int.Parse(port)); //sets serverIP with an new instantiate of IPEndPoint sets ip address and port
                listenerSocket.Bind(serverIP); //binds serverIp to listenerSocket
            }
            catch (SocketException ex)
            {
                serverWindow.ChatWindow("Can't start server " + ex, colorAlert); //prints text to screen
                StopServer();
            }

            clients = new List<ClientData>(); //instantiate list with new list
            serverWindow.ChatWindow("Start server on: " + NetworkFunctions.GetIP4Address() + ":" + port, colorSystem); //prints text to screen
            serverWindow.Started(true);
            started = true; //sets started to true
            listenThread = new Thread(ListenThread); //creats thread with ListenThread function
            listenThread.Start(); //starts listenThread
        }

        public static void StopServer() //call to stop server
        {
            started = false; //sets started to false

            //loop throw every client on the client list so we can close it
            foreach (ClientData client in clients) //foreach client in clients
            {
                client.clientSocket.Close(); //closes client socket
            }

            listenerSocket.Close(); //close socket
            listenThread.Abort();
            serverIP = null; //nulls serverIP
            clients.Clear(); //clears list
            serverWindow.Started(false);
            serverWindow.ChatWindow("Stoped server", colorAlert); //prints text to screen
        }

        static void ListenThread()
        {
            Thread.CurrentThread.IsBackground = true;

            while (started) //while started equal true
            {
                listenerSocket.Listen(0); //listen on listenerSocket
                Socket clientSocket = listenerSocket.Accept();
                ClientData client = new ClientData(clientSocket);
                clients.Add(client); //adds a new class instance of ClientData with new client and gets back clientID for the client
                client.clientThread = new Thread(() => Server.DataIn(client)); //sets clientThread to a new instance and passes input to function
                client.clientThread.IsBackground = true;
                client.clientThread.Start(); //starts client thread so we can get recive data from it
                client.SendRegistrationPacket(client.clientSocket); //sends registration packet to client
            }
        }

        static void DataIn(ClientData client) //might need to be static
        {
            while (started) //while started is true
            {
                try //tryes so we can catch SocketException
                {
                    byte[] buffer; //creats a buffer to store the data we receive
                    int readBytes; //creats a readBytes int so we can store how match byte was read that we received

                    buffer = new byte[client.clientSocket.SendBufferSize]; //sets buffer to the size of the data it will recived
                    readBytes = client.clientSocket.Receive(buffer); //sets readBytes with the size it receive so we know how big it is

                    if (readBytes == 0) //if data received is bigger then 0
                    {
                        serverWindow.ChatWindow("Client socket closed, Disconnecting " + client.name, colorAlert);
                        break;
                    }
                    DataManager(client, Packet.UnPack(buffer)); //unpackets data and calls DataManager
                }
                catch
                {
                    break;
                }
            }

            DisconnectClient(client);
            Thread.CurrentThread.Abort(); //aborts current thread
        }

        public static void DataOut(int PacketType, string[] sendData) //call to send data needs socket to send to and string to send
        {
            var content = Tuple.Create(PacketType, sendData); //creats a string array 2 entrys long
            byte[] packet = Packet.Pack(content);

            try
            {
                if (started && clients.Count > 0)
                {
                    foreach (ClientData client in clients)
                        client.clientSocket.Send(packet); //sends 
                }
                else
                    serverWindow.ChatWindow("No Clients to send to", colorAlert);
            }
            catch (SocketException sx)
            {
                serverWindow.ChatWindow("SocketException: " + sx, colorAlert);
            }
        }

        public static void DataOut(Socket socket, int PacketType, string[] sendData) //call to send data needs socket to send to and string to send
        {
            try
            {
                if (started && clients.Count > 0)
                {
                    var content = Tuple.Create(PacketType, sendData); //creats a string array 2 entrys long
                    socket.Send(Packet.Pack(content)); //sends 
                }
                else
                    serverWindow.ChatWindow("No Clients to send to", colorAlert);
            }
            catch (SocketException sx)
            {
                serverWindow.ChatWindow("SocketException: " + sx, colorAlert);
            }
        }

        public static void DataOutExcludeSender(Socket socket, int PacketType, string[] sendData) //call to send data needs socket to send to and string to send
        {
            var content = Tuple.Create(PacketType, sendData);
            byte[] pakcet = Packet.Pack(content);

            try
            {
                if (started && clients.Count > 0)
                {
                    foreach (ClientData client in clients)
                    {
                        if (client.clientSocket != socket)
                            client.clientSocket.Send(pakcet); //sends 
                    }
                }
                else
                    serverWindow.ChatWindow("No Clients to send to", colorAlert);
            }
            catch (SocketException sx)
            {
                serverWindow.ChatWindow("SocketException: " + sx, colorAlert);
            }
        }

        static void DataManager(ClientData client, Tuple<int, string[]> content) //handels data
        {
            if (content.Item1 >= 0 && content.Item1 <= 2)
            {
                switch (content.Item1)
                {
                    case 0: //chat
                        if (client.registerd && content.Item2.Length == 1)
                        {
                            serverWindow.ChatWindow(client.name + ": " + content.Item2[0], colorChat);

                            var newContent = new string[2];
                            newContent[0] = client.name;
                            newContent[1] = content.Item2[0];

                            DataOutExcludeSender(client.clientSocket, 0, newContent); //sends
                        }
                    break;

                    case 1: //specific chat
                        if (client.registerd && content.Item2.Length == 2)
                        {
                            if (client.name != content.Item2[0])
                            {
                                serverWindow.ChatWindow(client.name + " -> " + content.Item2[0] + ": " + content.Item2[1], colorSpecificChat);

                                var specificChat = new string[2];
                                specificChat[0] = client.name;
                                specificChat[1] = content.Item2[1];

                                Socket toClient = GetClientSocket(content.Item2[0]);

                                if (toClient != null)
                                    DataOut(toClient, 1, specificChat); //sends
                            }
                            else
                            {
                                DisconnectClient(client, "incorrect packet sent");
                            }
                        }
                    break;

                    case 2: //registration
                        if (IsBand(((IPEndPoint)client.clientSocket.RemoteEndPoint).Address))
                        {
                            DisconnectClient(client, "you are band");
                        }
                        else
                        if (CheckIfNamesTaken(content.Item2[0]))
                        {
                            DisconnectClient(client, "name already taken");
                        }
                        else
                        {
                            client.name = content.Item2[0];
                            client.registerd = true;
                            serverWindow.ClientList(client.name, false);
                            serverWindow.ChatWindow(client.name + " connected", colorConnect);

                            var clientName = new string[1];
                            clientName[0] = client.name;
                            DataOutExcludeSender(client.clientSocket, 3, clientName);
                        }
                    break;
                }
            }
            else
            {
                DisconnectClient(client, "disconnected for not being registerd");
            }
        }

        static bool CheckIfNamesTaken(string name)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].name == name)
                    return true;
            }
            return false;
        }

        public static Socket GetClientSocket(string name)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].name == name)
                    return clients[i].clientSocket;
            }
            return null;
        }

        public static ClientData GetClient(string name)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].name == name)
                    return clients[i];
            }
            return null;
        }

        static int GetClientIndex(ClientData Client) //NEED POLISH
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i] == Client)
                    return i;
            }
            return -1; //will make it throw an exaption as it will be index out of range
        }

        public static void DisconnectClient(string clientName)
        {
            ClientData client = GetClient(clientName);

            client.clientSocket.Close(); //closes client socket
            clients.Remove(client); //removes the client

            serverWindow.ClientList(client.name, true); //removes client name form clientListBox
            serverWindow.ChatWindow(client.name + " disconnected", colorDisconnect);

            //checks and sees if there is more then one client connected for if that is the case then it will send out packet that a client has disconnected
            if (clients.Count > 1)
            {
                var clientDisconnecting = new string[1];
                clientDisconnecting[0] = client.name;

                DataOutExcludeSender(client.clientSocket, 3, clientDisconnecting);
            }
        } //end of function DisconnectClient

        public static void DisconnectClient(string clientName, string message)
        {
            ClientData client = GetClient(clientName);

            var clientDisconnectingMessage = new string[2];
            clientDisconnectingMessage[0] = "Server";
            clientDisconnectingMessage[1] = message;
            DataOut(client.clientSocket, 0, clientDisconnectingMessage);

            client.clientSocket.Close(); //closes client socket
            clients.Remove(client); //removes the client

            serverWindow.ClientList(client.name, true); //removes client name form clientListBox
            serverWindow.ChatWindow(client.name + " disconnected: " + message, colorDisconnect);

            //checks and sees if there is more then one client connected for if that is the case then it will send out packet that a client has disconnected
            if (clients.Count > 1)
            {
                var clientDisconnecting = new string[1];
                clientDisconnecting[0] = client.name;

                DataOutExcludeSender(client.clientSocket, 3, clientDisconnecting);
            }
        } //end of function DisconnectClient

        public static void DisconnectClient(ClientData client)
        {
            client.clientSocket.Close(); //closes client socket
            clients.Remove(client); //removes the client

            serverWindow.ClientList(client.name, true); //removes client name form clientListBox
            serverWindow.ChatWindow(client.name + " disconnected", colorDisconnect);

            //checks and sees if there is more then one client connected for if that is the case then it will send out packet that a client has disconnected
            if (clients.Count > 1)
            {
                var clientDisconnecting = new string[1];
                clientDisconnecting[0] = client.name;

                DataOutExcludeSender(client.clientSocket, 3, clientDisconnecting);
            }
        } //end of function DisconnectClient

        public static void DisconnectClient(ClientData client, string message)
        {
            var clientDisconnectingMessage = new string[2];
            clientDisconnectingMessage[0] = "Server";
            clientDisconnectingMessage[1] = message;
            DataOut(client.clientSocket, 0, clientDisconnectingMessage);

            client.clientSocket.Close(); //closes client socket
            clients.Remove(client); //removes the client

            serverWindow.ClientList(client.name, true); //removes client name form clientListBox
            serverWindow.ChatWindow(client.name + " disconnected: " + message, colorDisconnect);

            //checks and sees if there is more then one client connected for if that is the case then it will send out packet that a client has disconnected
            if (clients.Count > 1)
            {
                var clientDisconnecting = new string[1];
                clientDisconnecting[0] = client.name;

                DataOutExcludeSender(client.clientSocket, 3, clientDisconnecting);
            }
        }//end of function DisconnectClient

        public static void AddToManagedClients()
        {
            CheckXML();
            isDataTableUpdating = true;

                var clientInfo =
                    new XElement("Client",
                        new XAttribute("Name", ""),
                        new XAttribute("Address", ""),
                        new XAttribute("Band", false),
                        new XAttribute("Reason", "")
                );

                managedClientsXML.Element("Clients").Add(clientInfo);
                managedClientsXML.Save("ManagedClients.xml");
        }

        public static void AddToManagedClients(string name)
        {
            CheckXML();
            isDataTableUpdating = true;
            ClientData client = GetClient(name);

            int a = 0;
            int c = managedClientsXML.Descendants("Client").Count();

            if(managedClientsXML.Descendants("Client").Any())
            {
                foreach (var fromManagedClientsXML in managedClientsXML.Descendants("Client"))
                {
                    a++;

                    if (client.clientSocket.RemoteEndPoint.ToString() == fromManagedClientsXML.Attribute("Address").Value)
                    {
                        break;
                    }

                    if (a == c)
                    {
                        var clientInfo =
                            new XElement("Client",
                                new XAttribute("Name", name),
                                new XAttribute("Address", ((IPEndPoint)client.clientSocket.RemoteEndPoint).Address),
                                new XAttribute("Band", false),
                                new XAttribute("Reason", "")
                        );

                        managedClientsXML.Element("Clients").Add(clientInfo);
                        managedClientsXML.Save("ManagedClients.xml");

                        break;
                    }
                }
            }
            else
            {
                var clientInfo =
                    new XElement("Client",
                        new XAttribute("Name", name),
                        new XAttribute("Address", ((IPEndPoint)client.clientSocket.RemoteEndPoint).Address),
                        new XAttribute("Band", false),
                        new XAttribute("Reason", "")
                );

                managedClientsXML.Element("Clients").Add(clientInfo);
                managedClientsXML.Save("ManagedClients.xml");
            }
            
        }

        public static void AddToManagedClients(string name, bool bandFromServer)
        {
            CheckXML();
            isDataTableUpdating = true;
            ClientData client = GetClient(name);

            int a = 0;
            int c = managedClientsXML.Descendants("Client").Count();

            if (managedClientsXML.Descendants("Client").Any())
            {
                foreach (var fromManagedClientsXML in managedClientsXML.Descendants("Client"))
                {
                    a++;

                    if (client.clientSocket.RemoteEndPoint.ToString() == fromManagedClientsXML.Attribute("Address").Value)
                        break;

                    if (a == c)
                    {
                        var clientInfo =
                            new XElement("Client",
                                new XAttribute("Name", name),
                                new XAttribute("Address", ((IPEndPoint)client.clientSocket.RemoteEndPoint).Address),
                                new XAttribute("Band", bandFromServer),
                                new XAttribute("Reason", "")
                            );

                        managedClientsXML.Element("Clients").Add(clientInfo);
                        managedClientsXML.Save("ManagedClients.xml");

                        break;
                    }
                }
            }
            else
            {
                var clientInfo =
                    new XElement("Client",
                    new XAttribute("Name", name),
                    new XAttribute("Address", ((IPEndPoint)client.clientSocket.RemoteEndPoint).Address),
                    new XAttribute("Band", bandFromServer),
                    new XAttribute("Reason", "")
                );

                managedClientsXML.Element("Clients").Add(clientInfo);
                managedClientsXML.Save("ManagedClients.xml");
            }
        }

        public static void AddToManagedClients(string name, bool bandFromServer, string reason) //-------------MIGHT REMOVE
        {
            CheckXML();
            isDataTableUpdating = true;
            ClientData client = GetClient(name);

            int a = 0;
            int c = managedClientsXML.Descendants("Client").Count();

            if (managedClientsXML.Descendants("Client").Any())
            {
                foreach (var fromManagedClientsXML in managedClientsXML.Descendants("Client"))
                {
                    a++;

                    if (client.clientSocket.RemoteEndPoint.ToString() == fromManagedClientsXML.Attribute("Address").Value)
                        break;

                    if (a == c)
                    {
                        var clientInfo =
                            new XElement("Client",
                                new XAttribute("Name", name),
                                new XAttribute("Address", client.clientSocket.RemoteEndPoint),
                                new XAttribute("Band", bandFromServer),
                                new XAttribute("Reason", reason)
                            );

                        managedClientsXML.Element("Clients").Add(clientInfo);
                        managedClientsXML.Save("ManagedClients.xml");

                        break;
                    }
                }
            }
            else
            {
                var clientInfo =
                    new XElement("Client",
                        new XAttribute("Name", name),
                        new XAttribute("Address", client.clientSocket.RemoteEndPoint),
                        new XAttribute("Band", bandFromServer),
                        new XAttribute("Reason", reason)
                    );

                managedClientsXML.Element("Clients").Add(clientInfo);
                managedClientsXML.Save("ManagedClients.xml");
            }
        }

        public static void RemoveManagedClients(string endPoint)
        {
            CheckXML();
            isDataTableUpdating = true;
            if (File.Exists("ManagedClients.xml") && endPoint != null)
            {
                foreach (var client in managedClientsXML.Descendants("Client"))
                {
                    if(client.Attribute("Address").Value == endPoint)
                    {
                        client.Remove();
                        managedClientsXML.Save("ManagedClients.xml");
                        break;
                    }
                }
            }
        }

        public static void CheckXML()
        {
            if (!File.Exists("ManagedClients.xml"))
            {
                managedClientsXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XComment("All managed Clients are here"),
                    new XElement("Clients"));

                managedClientsXML.Save("ManagedClients.xml");

                managedClientsXML = XDocument.Load("ManagedClients.xml");
            }
            else
            if (managedClientsXML == null)
                managedClientsXML = XDocument.Load("ManagedClients.xml");
        }

        static bool IsBand(IPAddress ipAddress)
        {
            CheckXML();

            var ips = managedClientsXML.Descendants().Elements("Client").AsEnumerable().ToArray();
            for (int i = 0; i < ips.Length; i++)
            {
                if (ips[i].Attribute("Address").Value == ipAddress.ToString() && (Convert.ToBoolean(ips[i].Attribute("Band").Value)))
                {
                    return true;
                }
            }
            return false;
        }

    } //end of class Server

    public class ClientData //receive from class
    {
        public Socket clientSocket; //client socket
        public Thread clientThread; //client thread
        public bool registerd; //if the client is registerd or not
        public string name; //name of client
        public string id; //ID for the client

        public ClientData(Socket clientSocket) //class constructor
        {
            this.clientSocket = clientSocket; //local clientSocket have the same data as client socket
            id = Guid.NewGuid().ToString(); //generates a string as ID for the client
        }

        public void SendRegistrationPacket(Socket clientSocket) //sends registration packet to the client needs socket to send to
        {
            if (clientSocket != null) //if clientSocket isn't null
            {
                if(Server.clients.Count > 1)
                {
                    var content = new string[Server.clients.Count - 1];

                    int a = 0;
                    for (int i = 0; i < Server.clients.Count; i++)
                    {
                        if (Server.clients[i].name != null)
                        {
                            content[a] = Server.clients[i].name;
                            a++;
                        }
                    }
                    Server.DataOut(clientSocket, 2, content);
                }
                else
                {
                    var content = new string[1];
                    Server.DataOut(clientSocket, 2, content);
                }
            }
        }

    } //end of class ClientData

} //end of namespace
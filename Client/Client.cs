using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using Networking.Data;
using Networking.Client.Window;

namespace Networking.Client //creats a namespace so we can use any name for the call we want and so it is easy to access form other scripts
{
    [System.Serializable]
    public class Client //creats a class
    {
        static Socket masterSocket; //masterSocket
        static ClientWindow clientWindow; //UI
        public static List<string> clients; //creats a list so we can store all the clients in it
        public static string port; //creats a sting so we can store the port
        public static string ipAddress; //creats a sting so we can store the ip address
        public static string name = string.Empty; //the clients name
        public static bool connected; //is it connected

        public static Color colorSystem = Color.Green;
        public static Color colorAlert = Color.Red;
        public static Color colorConnect = Color.DarkGreen;
        public static Color colorDisconnect = Color.Orange;
        public static Color colorChat = Color.DarkBlue;
        public static Color colorSpecificChat = Color.Purple;

        [STAThread]
        static void Main() //entry point function of the program
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(clientWindow = new ClientWindow());
        }

        public static void Connect() //call this to connect to a server
        {
            clients = new List<string>(); //instantiate list with new list
            connected = true; //sets connected to true so we know it is connected

            try //try so we can catch any exception
            {
                masterSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //sets socket with AddressFamily, SocketType, and ProtocolType
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ipAddress), int.Parse(port)); //creats an IPEndPoint and sets it with ipAddress and port
                masterSocket.Connect(ipe); //connects to the server
            }
            catch //catches any exception
            {
                clientWindow.ChatWindow("Could not connect to host!", colorAlert); //prints text to screen
                Disconnect();
            }
            
            Thread dataInThread = new Thread(DataIn); //creats a thread that will run DataIN function
            dataInThread.Start(); //starts dataInThread thread
        }

        public static void Disconnect() //call this to Disconnect the client
        {
            clients.Clear();
            connected = false; //sets connected to false
            clientWindow.Connected(false);
            masterSocket.Close(); //closes the socket
        }

        static void DataIn() //might need to be static
        {
            while (connected) //while connected is true
            {
                try //trys so we can catch SocketException if the server disconnects
                {
                    byte[] buffer; //creats a buffer to store the data we receive
                    int readBytes; //creats a readBytes int so we can store how match byte was read that we received

                    buffer = new byte[masterSocket.SendBufferSize]; //sets buffer to the size of the data it will recived
                    readBytes = masterSocket.Receive(buffer); //sets readBytes with the size it receive so we know how big it is

                    if (readBytes == 0) //if data received is bigger then 0
                    {
                        throw new SocketException();
                    }
                    DataManager(Packet.UnPack(buffer)); //unpackets data and calls DataManager
                }
                catch(SocketException se) //catches SocketException
                {
                    clientWindow.ChatWindow("Disconnected", colorAlert); //prints text to screen
                    Disconnect(); //disconnects client
                }
            }
        } //end of DataIN

        public static void DataOut(int packetType, string[] sendData)
        {
            var content = Tuple.Create(packetType, sendData); //creats a string array 2 entrys long
            masterSocket.Send(Packet.Pack(content)); //packets data and sends it to the server
        } //end of DataOUT

        static void DataManager(Tuple<int, string[]> content) //handels data
        {
            if(content.Item1 >= 0 && content.Item1 <= 3)
            {
                switch (content.Item1)
                {
                    case 0: //chat
                        if (content.Item2.Length == 2 && content.Item2 != null)
                            clientWindow.ChatWindow(content.Item2[0] + ": " + content.Item2[1], colorChat);
                    break;

                    case 1: //specific chat
                        if (content.Item2.Length == 2 && content.Item2 != null)
                            clientWindow.ChatWindow(content.Item2[0] + " -> " + name + ": " + content.Item2[1], colorSpecificChat);
                    break;

                    case 2: //registration
                        if (content.Item2.Length > 0)
                        {
                            foreach (string clientName in content.Item2)
                            {
                                if (clientName != null && clientName != string.Empty && clientName != name)
                                {
                                    clientWindow.ClientList(clientName, false);
                                    clients.Add(clientName);
                                }
                            }
                        }
                        var registration = new string[1];
                        registration[0] = name;
                        DataOut(2, registration);
                        clientWindow.Connected(true);
                        clientWindow.ChatWindow("Connected to server", colorSystem);
                    break;

                    case 3: //client list
                        if (content.Item2.Length > 0 && content.Item2 != null)
                        {
                            if (clients.Count > 0)
                            {
                                for (int i = 0; i < clients.Count; i++)
                                {
                                    if (clients[i] == content.Item2[0])
                                    {
                                        clientWindow.ChatWindow(content.Item2[0] + " disconnected", colorDisconnect);
                                        clientWindow.ClientList(content.Item2[0], true);
                                        clients.Remove(content.Item2[0]);
                                        break;
                                    }

                                    if (i == clients.Count - 1)
                                    {
                                        clientWindow.ChatWindow(content.Item2[0] + " connected", colorConnect);
                                        clientWindow.ClientList(content.Item2[0], false);
                                        clients.Add(content.Item2[0]);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (content.Item2[0] != null)
                                {
                                    clientWindow.ChatWindow(content.Item2[0] + " connected", colorConnect);
                                    clientWindow.ClientList(content.Item2[0], false);
                                    clients.Add(content.Item2[0]);
                                }
                            }
                        }
                    break;
                }
            }
        }//end of DataManger
    } //end of class client

} //end of namespace
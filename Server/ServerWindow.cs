using System;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;


namespace Networking.Server.Window
{
    public partial class ServerWindow : Form
    {
        static Server server = new Server();
        static string selectedClient;
        delegate void StartedDelegate(bool started);
        delegate void ChatDelegate(string message, Color color);
        delegate void ClientListDelegate(string clientName, bool remove);

        public ServerWindow()
        {
            InitializeComponent();
        }

        public void Started(bool started)
        {
            if (startButton.InvokeRequired)
            {
                var threadSafe = new StartedDelegate(LocalStarted);
                Invoke(threadSafe, new bool[]{started});
            }
            else
            {
                LocalStarted(started);
            }
        }

        public void ChatWindow(string message, Color color)
        {
            if (chatRichTextBox.InvokeRequired)
            {
                var threadSafe = new ChatDelegate(LocalChatWindow);
                Invoke(threadSafe, new object[]{message, color});
            }
            else
            {
                LocalChatWindow(message, color);
            }
        }

        public void ClientList(string clientName, bool remove)
        {
            if (clientListBox.InvokeRequired && chatRichTextBox.InvokeRequired)
            {
                var threadSafe = new ClientListDelegate(LocalClientList);
                Invoke(threadSafe, new object[]{clientName, remove});
            }
            else
            {
                LocalClientList(clientName, remove);
            }
        }

        void LocalStarted(bool started)
        {
            if (started)
            {
                portTextBox.Enabled = false;
                startButton.Text = "Stop";
            }
            else
            {
                sendButton.Enabled = false;
                portTextBox.Enabled = true;
                startButton.Text = "Start";
                clientListBox.Items.Clear();
            }
        }

        void LocalChatWindow(string message, Color color)
        {
            chatRichTextBox.SelectionColor = color;

            if (chatRichTextBox.Text.Length > 0)
                chatRichTextBox.AppendText("\n" + message);
            else
                chatRichTextBox.AppendText(message);

            chatRichTextBox.SelectionColor = Color.Black;
        }

        void LocalClientList(string clientName, bool remove)
        {
            if(clientName != null)
            {
                if (remove)
                {
                    clientListBox.Items.Remove(clientName);

                    if (clientListBox.Items.Count < 0)
                        sendButton.Enabled = false;

                }
                else
                {
                    clientListBox.Items.Add(clientName);

                    if (!sendButton.Enabled)
                        sendButton.Enabled = true;
                }
            }
        }

        void ServerWindow_Load(object sender, EventArgs e)
        {
            sendButton.Enabled = false;
        }

        void StartButton_Click(object sender, EventArgs e)
        {
            if (Server.started)
            {
                Started(false);
                Server.StopServer();
            }
            else
            {
                if (NetworkLib.NetworkFunctions.CheckPortValid(portTextBox.Text))
                {
                    if (Server.started)
                        Started(false);
                    else
                        Started(true);

                    Server.port = portTextBox.Text;
                    Server.StartServer();
                }
                else
                {
                    portTextBox.BackColor = Color.Red;
                }
            }
        }

        void PortTextBox_TextChanged(object sender, EventArgs e)
        {
            if (portTextBox.BackColor == Color.Red)
                portTextBox.BackColor = Color.White;
        }

        void SendButton_Click(object sender, EventArgs e)
        {
            if (Server.started && messageTextBox.TextLength > 0 && Server.clients.Count > 0)
            {
                if (selectedClient != string.Empty && selectedClient != null)
                {
                    var message = new string[2];
                    message[0] = "Server";
                    message[1] = messageTextBox.Text;

                    Socket clientSocket = Server.GetClientSocket(selectedClient);

                    if (clientSocket != null)
                    {
                        LocalChatWindow("Server" + " -> " + selectedClient + ": " + messageTextBox.Text, Color.Purple);
                        Server.DataOut(clientSocket, 1, message);
                        messageTextBox.Clear();
                        clientListBox.ClearSelected();
                    }
                }
                else
                {
                    var message = new string[2];
                    message[0] = "Server";
                    message[1] = messageTextBox.Text;

                    LocalChatWindow("Server: " + messageTextBox.Text, Color.DarkBlue);
                    Server.DataOut(0, message);
                    messageTextBox.Clear();
                    clientListBox.ClearSelected();
                }
            }
        }

        void ClientListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedClient == clientListBox.GetItemText(clientListBox.SelectedItem))
            {
                clientListBox.ClearSelected();
                selectedClient = string.Empty;

                string temp = messageTextBox.Text;
                messageTextBox.Clear();
                messageTextBox.SelectionColor = Server.colorChat;
                messageTextBox.AppendText(temp);
            }
            else
            {
                selectedClient = clientListBox.GetItemText(clientListBox.SelectedItem);

                messageTextBox.Clear();
                messageTextBox.SelectionColor = Server.colorSpecificChat;
                messageTextBox.AppendText(messageTextBox.Text);
            }
        }

        void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if(selectedClient == string.Empty || selectedClient == null)
                messageTextBox.SelectionColor = Server.colorChat;
            else if (selectedClient != string.Empty || selectedClient != null)
                messageTextBox.SelectionColor = Server.colorSpecificChat;  
        }

        void clearChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chatRichTextBox.Clear();
        }

        void clientManagerButton_Click(object sender, EventArgs e)
        {
            var clientManagerWindow = new ClientManagerWindow();
            clientManagerWindow.Show();
        }

        void AddToManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string clientName = clientListBox.GetItemText(clientListBox.SelectedItem);
            if (clientName != null && clientName != string.Empty && selectedClient != null && selectedClient != string.Empty)
            {
                Server.AddToManagedClients(clientName);
                ClientManagerWindow.UpdateDataTable();
            }
        }

        void KickClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientData client = Server.GetClient((string)clientListBox.SelectedItem);

            string clientName = clientListBox.GetItemText(clientListBox.SelectedItem);
            if (clientName != null && clientName != string.Empty && selectedClient != null && selectedClient != string.Empty)
            {
                Server.DisconnectClient(clientName, "Disconnected by server");
            }
        }

        void BanClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string clientName = clientListBox.GetItemText(clientListBox.SelectedItem);
            if (clientName != null && clientName != string.Empty && selectedClient != null && selectedClient != string.Empty)
            {
                Server.AddToManagedClients(clientName, true);
                ClientManagerWindow.UpdateDataTable();
                Server.DisconnectClient(clientName, "Disconnected by server");
            }
        }

    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Networking.Client.Window
{
    public partial class ClientWindow : Form
    {
        static Client client = new Client();
        static string selectedClient;
        delegate void ConnectedDelegate(bool connected);
        delegate void ChatDelegate(string message, Color color);
        delegate void ClientListDelegate(string clientName, bool remove);

        public ClientWindow()
        {
            InitializeComponent();
        }

        public void Connected(bool connected) //NEED POLISH
        {
            if (connectButton.InvokeRequired && ipTextBox.InvokeRequired && portTextBox.InvokeRequired && nameTextBox.InvokeRequired && sendButton.InvokeRequired) //this might be a bug here
            {
                var threadSafe = new ConnectedDelegate(LocalConnected);
                Invoke(threadSafe, new object[]{connected});
            }
            else
            {
                LocalConnected(connected);
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
            if (clientListBox.InvokeRequired)
            {
                var threadSafe = new ClientListDelegate(LocalClientList);
                Invoke(threadSafe, new object[] { clientName, remove });
            }
            else
            {
                LocalClientList(clientName, remove);
            }
        }

        void LocalConnected(bool connected)
        {
            if (connected)
            {
                Client.name = nameTextBox.Text;
                ipTextBox.Enabled = false;
                portTextBox.Enabled = false;
                nameTextBox.Enabled = false;
                connectButton.Text = "Disconnect";
                sendButton.Enabled = true;
            }
            else
            {
                Client.name = string.Empty;
                sendButton.Enabled = false;
                ipTextBox.Enabled = true;
                portTextBox.Enabled = true;
                nameTextBox.Enabled = true;
                connectButton.Text = "Connect";
                clientListBox.Items.Clear();
                sendButton.Enabled = false;
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
            if (clientName != null)
            {
                if (remove)
                {
                    clientListBox.Items.Remove(clientName);

                    if (clientListBox.Items.Count <= 0)
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

        void ClientWindow_Load(object sender, EventArgs e)
        {
            sendButton.Enabled = false;
        }

        void ConnectButton_Click(object sender, EventArgs e)
        {
            if (Client.connected)
            {
                Connected(false);
                Client.Disconnect();
            }
            else
            {
                bool ip = false;
                bool port = false;
                bool name = false;

                if (NetworkLib.NetworkFunctions.CheckIPv4Valid(ipTextBox.Text))
                {
                    Client.ipAddress = ipTextBox.Text;
                    ip = true;
                }
                else
                {
                    ipTextBox.BackColor = Color.Red;
                    if (ip)
                        ip = false;
                }

                if (NetworkLib.NetworkFunctions.CheckPortValid(portTextBox.Text))
                {
                    Client.port = portTextBox.Text;
                    port = true;
                }
                else
                {
                    portTextBox.BackColor = Color.Red;
                    if (port)
                        port = false;
                }

                if (nameTextBox.Text.Length > 0)
                {
                    Client.name = nameTextBox.Text;
                    name = true;
                }
                else
                {
                    nameTextBox.BackColor = Color.Red;
                    if (name)
                        name = false;
                }

                if (ip && port && name)
                {
                    Client.Connect();
                }
            }
        }

        void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (nameTextBox.BackColor == Color.Red)
                nameTextBox.BackColor = Color.White;
        }

        void IPTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ipTextBox.BackColor == Color.Red)
                ipTextBox.BackColor = Color.White;
        }

        void PortTextBox_TextChanged(object sender, EventArgs e)
        {
            if (portTextBox.BackColor == Color.Red)
                portTextBox.BackColor = Color.White;
        }

        void SendButton_Click(object sender, EventArgs e)
        {
            if (Client.connected && messageTextBox.TextLength > 0)
            {
                if (selectedClient != string.Empty && selectedClient != null)
                {
                    var message = new string[2];
                    message[0] = selectedClient;
                    message[1] = messageTextBox.Text;

                    LocalChatWindow(Client.name + " -> " + selectedClient + ": " + messageTextBox.Text, Client.colorSpecificChat);
                    Client.DataOut(1, message);
                    messageTextBox.Clear();
                    clientListBox.ClearSelected();
                }
                else
                {
                    var message = new string[1];
                    message[0] = messageTextBox.Text;

                    LocalChatWindow(Client.name + ": " + messageTextBox.Text, Client.colorChat);
                    Client.DataOut(0, message);
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
                messageTextBox.SelectionColor = Client.colorChat;
                messageTextBox.AppendText(temp);
            }
            else
            {
                selectedClient = clientListBox.GetItemText(clientListBox.SelectedItem);

                string temp = messageTextBox.Text;
                messageTextBox.Clear();
                messageTextBox.SelectionColor = Client.colorSpecificChat;
                messageTextBox.AppendText(temp);
            }
        }

        void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (selectedClient == string.Empty || selectedClient == null)
                messageTextBox.SelectionColor = Client.colorChat;
            else if (selectedClient != string.Empty || selectedClient != null)
                messageTextBox.SelectionColor = Client.colorSpecificChat;
        }

        void ClearChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chatRichTextBox.Clear();
        }
    }
}
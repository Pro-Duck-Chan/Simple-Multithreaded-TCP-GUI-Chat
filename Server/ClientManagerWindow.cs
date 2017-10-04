using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace Networking.Server.Window
{
    public partial class ClientManagerWindow : Form
    {
        public static DataTable dataTable = new DataTable();

        public ClientManagerWindow()
        {
            InitializeComponent();
            dataGridViewClientManager.DataSource = dataTable;
        }

        public static void CheckXML()
        {
            if (!File.Exists("ManagedClients.xml"))
            {
                Server.managedClientsXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XComment("All managed Clients are here"),
                    new XElement("Clients"));

                Server.managedClientsXML.Save("ManagedClients.xml");

                Server.managedClientsXML = XDocument.Load("ManagedClients.xml");
            }
            else
            if (Server.managedClientsXML == null)
                Server.managedClientsXML = XDocument.Load("ManagedClients.xml");
        }

        public static void UpdateDataTable()
        {
            CheckXML();

            if (dataTable.Columns.Count <= 0)
            {
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("Address", typeof(string));
                dataTable.Columns.Add("Band", typeof(bool));
                dataTable.Columns.Add("Reason", typeof(string));
            }

            if (File.Exists("ManagedClients.xml"))
            {
                if (dataTable.Rows.Count <= 0)
                {
                    foreach (var client in Server.managedClientsXML.Descendants("Client"))
                    {
                        dataTable.Rows.Add(client.Attribute("Name").Value, client.Attribute("Address").Value, client.Attribute("Band").Value, client.Attribute("Reason").Value);
                    }
                }
                else
                {
                    dataTable.Clear();

                    foreach (var client in Server.managedClientsXML.Descendants("Client"))
                    {
                        dataTable.Rows.Add(client.Attribute("Name").Value, client.Attribute("Address").Value, client.Attribute("Band").Value, client.Attribute("Reason").Value);
                    }
                }
            }
            else
            {
                dataTable.Clear();
            }
        }

        void ClientManagerWindow_Load(object sender, System.EventArgs e)
        {
            UpdateDataTable();
        }

        public static void RemoveFromDataTable(string clientEndPoint)
        {
            Server.CheckXML();

            if (File.Exists("ManagedClients.xml"))
            {
                int clients = Server.managedClientsXML.Elements("Clients").Count();

                for (int i = 0; i < Server.managedClientsXML.Descendants("Client").Count(); i++)
                {
                    Server.managedClientsXML.Descendants("Client").ToArray()[i].Remove();
                    break;
                }
            }

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.Field<String>("Address") == clientEndPoint)
                {
                    dataTable.Rows.Remove(row);
                    break;
                }
            }

        }

        public static void ChangeDataTable(DataGridViewCell currentCell)
        {
            var managedClients = Server.managedClientsXML.Descendants().Elements("Client").AsEnumerable().ToArray();

                switch (currentCell.ColumnIndex)
                {
                    case 0:
                            managedClients[currentCell.RowIndex].Attribute("Name").Value = currentCell.Value.ToString();
                    break;

                    case 1:
                            managedClients[currentCell.RowIndex].Attribute("Address").Value = (Convert.ToBoolean(currentCell.Value)).ToString();
                    break;

                    case 2:
                            managedClients[currentCell.RowIndex/*here*/].Attribute("Band").Value = currentCell.Value.ToString(); //index out of range
                    break;

                    case 3:
                            managedClients[currentCell.RowIndex].Attribute("Reason").Value = currentCell.Value.ToString();
                    break;
                }

            Server.managedClientsXML.Save("ManagedClients.xml");
            UpdateDataTable();
        }

        void AddClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Server.AddToManagedClients();
            UpdateDataTable();
        }

        void RemoveClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Server.RemoveManagedClients(dataGridViewClientManager.CurrentRow.Cells[1].Value.ToString());
            RemoveFromDataTable(dataGridViewClientManager.CurrentRow.Cells[1].Value.ToString());
        }

        void DataGridViewClientManager_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewClientManager.CurrentCell != null && dataGridViewClientManager.RowCount > 0 && dataGridViewClientManager.CurrentCell.RowIndex <= dataGridViewClientManager.RowCount && !Server.isDataTableUpdating) //here cast to string but also value might not be string
                ChangeDataTable(dataGridViewClientManager.CurrentCell);

            if(Server.isDataTableUpdating)
             Server.isDataTableUpdating = false;
        }
    }
}           

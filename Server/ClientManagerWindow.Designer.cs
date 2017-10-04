namespace Networking.Server.Window
{
    partial class ClientManagerWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStripClientManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewClientManager = new System.Windows.Forms.DataGridView();
            this.contextMenuStripClientManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientManager)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripClientManager
            // 
            this.contextMenuStripClientManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClientToolStripMenuItem,
            this.removeClientToolStripMenuItem});
            this.contextMenuStripClientManager.Name = "contextMenuStripClientManager";
            this.contextMenuStripClientManager.Size = new System.Drawing.Size(152, 48);
            // 
            // addClientToolStripMenuItem
            // 
            this.addClientToolStripMenuItem.Name = "addClientToolStripMenuItem";
            this.addClientToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addClientToolStripMenuItem.Text = "Add Client";
            this.addClientToolStripMenuItem.Click += new System.EventHandler(this.AddClientToolStripMenuItem_Click);
            // 
            // removeClientToolStripMenuItem
            // 
            this.removeClientToolStripMenuItem.Name = "removeClientToolStripMenuItem";
            this.removeClientToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.removeClientToolStripMenuItem.Text = "Remove Client";
            this.removeClientToolStripMenuItem.Click += new System.EventHandler(this.RemoveClientToolStripMenuItem_Click);
            // 
            // dataGridViewClientManager
            // 
            this.dataGridViewClientManager.AllowUserToAddRows = false;
            this.dataGridViewClientManager.AllowUserToDeleteRows = false;
            this.dataGridViewClientManager.AllowUserToResizeColumns = false;
            this.dataGridViewClientManager.AllowUserToResizeRows = false;
            this.dataGridViewClientManager.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewClientManager.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewClientManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientManager.ContextMenuStrip = this.contextMenuStripClientManager;
            this.dataGridViewClientManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClientManager.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewClientManager.MultiSelect = false;
            this.dataGridViewClientManager.Name = "dataGridViewClientManager";
            this.dataGridViewClientManager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewClientManager.Size = new System.Drawing.Size(544, 270);
            this.dataGridViewClientManager.TabIndex = 1;
            this.dataGridViewClientManager.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewClientManager_CellEndEdit);
            // 
            // ClientManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 270);
            this.Controls.Add(this.dataGridViewClientManager);
            this.MaximumSize = new System.Drawing.Size(560, 999999975);
            this.MinimumSize = new System.Drawing.Size(560, 300);
            this.Name = "ClientManagerWindow";
            this.Text = "Client Manager";
            this.Load += new System.EventHandler(this.ClientManagerWindow_Load);
            this.contextMenuStripClientManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripClientManager;
        private System.Windows.Forms.ToolStripMenuItem removeClientToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewClientManager;
        private System.Windows.Forms.ToolStripMenuItem addClientToolStripMenuItem;
    }
}
namespace Networking.Client.Window
{
    public partial class ClientWindow
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
            this.controllBox = new System.Windows.Forms.GroupBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.clientListBox = new System.Windows.Forms.ListBox();
            this.chatContainer = new System.Windows.Forms.SplitContainer();
            this.chatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.messageTextBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.contextMenuStripChat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controllBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatContainer)).BeginInit();
            this.chatContainer.Panel1.SuspendLayout();
            this.chatContainer.Panel2.SuspendLayout();
            this.chatContainer.SuspendLayout();
            this.contextMenuStripChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // controllBox
            // 
            this.controllBox.Controls.Add(this.ipLabel);
            this.controllBox.Controls.Add(this.ipTextBox);
            this.controllBox.Controls.Add(this.portLabel);
            this.controllBox.Controls.Add(this.portTextBox);
            this.controllBox.Controls.Add(this.nameLabel);
            this.controllBox.Controls.Add(this.nameTextBox);
            this.controllBox.Controls.Add(this.connectButton);
            this.controllBox.Location = new System.Drawing.Point(12, 12);
            this.controllBox.Name = "controllBox";
            this.controllBox.Size = new System.Drawing.Size(385, 64);
            this.controllBox.TabIndex = 0;
            this.controllBox.TabStop = false;
            this.controllBox.Text = "Connect To Server";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(3, 16);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(58, 13);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "IP Address";
            // 
            // ipTextBox
            // 
            this.ipTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.ipTextBox.Location = new System.Drawing.Point(6, 32);
            this.ipTextBox.MaximumSize = new System.Drawing.Size(87, 20);
            this.ipTextBox.MaxLength = 15;
            this.ipTextBox.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(87, 20);
            this.ipTextBox.TabIndex = 0;
            this.ipTextBox.TextChanged += new System.EventHandler(this.IPTextBox_TextChanged);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(96, 16);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "Port";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(99, 32);
            this.portTextBox.MaximumSize = new System.Drawing.Size(36, 20);
            this.portTextBox.MaxLength = 5;
            this.portTextBox.MinimumSize = new System.Drawing.Size(36, 20);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(36, 20);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.TextChanged += new System.EventHandler(this.PortTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(138, 16);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(141, 32);
            this.nameTextBox.MaxLength = 20;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(125, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(272, 16);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(103, 36);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // clientListBox
            // 
            this.clientListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientListBox.FormattingEnabled = true;
            this.clientListBox.IntegralHeight = false;
            this.clientListBox.Location = new System.Drawing.Point(403, 82);
            this.clientListBox.Name = "clientListBox";
            this.clientListBox.Size = new System.Drawing.Size(125, 389);
            this.clientListBox.Sorted = true;
            this.clientListBox.TabIndex = 6;
            this.clientListBox.SelectedIndexChanged += new System.EventHandler(this.ClientListBox_SelectedIndexChanged);
            // 
            // chatContainer
            // 
            this.chatContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatContainer.Location = new System.Drawing.Point(12, 82);
            this.chatContainer.Name = "chatContainer";
            this.chatContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // chatContainer.Panel1
            // 
            this.chatContainer.Panel1.Controls.Add(this.chatRichTextBox);
            this.chatContainer.Panel1MinSize = 20;
            // 
            // chatContainer.Panel2
            // 
            this.chatContainer.Panel2.Controls.Add(this.messageTextBox);
            this.chatContainer.Panel2MinSize = 20;
            this.chatContainer.Size = new System.Drawing.Size(385, 467);
            this.chatContainer.SplitterDistance = 389;
            this.chatContainer.TabIndex = 4;
            // 
            // chatRichTextBox
            // 
            this.chatRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatRichTextBox.ContextMenuStrip = this.contextMenuStripChat;
            this.chatRichTextBox.Location = new System.Drawing.Point(-1, -1);
            this.chatRichTextBox.Name = "chatRichTextBox";
            this.chatRichTextBox.ReadOnly = true;
            this.chatRichTextBox.Size = new System.Drawing.Size(385, 389);
            this.chatRichTextBox.TabIndex = 5;
            this.chatRichTextBox.Text = "";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageTextBox.Location = new System.Drawing.Point(-1, -1);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(385, 74);
            this.messageTextBox.TabIndex = 7;
            this.messageTextBox.Text = "";
            this.messageTextBox.TextChanged += new System.EventHandler(this.MessageTextBox_TextChanged);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.AutoSize = true;
            this.sendButton.Location = new System.Drawing.Point(403, 475);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(125, 74);
            this.sendButton.TabIndex = 8;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // contextMenuStripChat
            // 
            this.contextMenuStripChat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearChatToolStripMenuItem});
            this.contextMenuStripChat.Name = "contextMenuStripChat";
            this.contextMenuStripChat.Size = new System.Drawing.Size(130, 26);
            // 
            // clearChatToolStripMenuItem
            // 
            this.clearChatToolStripMenuItem.Name = "clearChatToolStripMenuItem";
            this.clearChatToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.clearChatToolStripMenuItem.Text = "Clear Chat";
            this.clearChatToolStripMenuItem.Click += new System.EventHandler(this.ClearChatToolStripMenuItem_Click);
            // 
            // ClientWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 561);
            this.Controls.Add(this.controllBox);
            this.Controls.Add(this.clientListBox);
            this.Controls.Add(this.chatContainer);
            this.Controls.Add(this.sendButton);
            this.MinimumSize = new System.Drawing.Size(556, 600);
            this.Name = "ClientWindow";
            this.RightToLeftLayout = true;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.ClientWindow_Load);
            this.controllBox.ResumeLayout(false);
            this.controllBox.PerformLayout();
            this.chatContainer.Panel1.ResumeLayout(false);
            this.chatContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chatContainer)).EndInit();
            this.chatContainer.ResumeLayout(false);
            this.contextMenuStripChat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox controllBox;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ListBox clientListBox;
        private System.Windows.Forms.SplitContainer chatContainer;
        private System.Windows.Forms.RichTextBox chatRichTextBox;
        private System.Windows.Forms.RichTextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChat;
        private System.Windows.Forms.ToolStripMenuItem clearChatToolStripMenuItem;
    }
}
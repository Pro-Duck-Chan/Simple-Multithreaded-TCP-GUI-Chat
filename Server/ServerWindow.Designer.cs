namespace Networking.Server.Window
{
    public partial class ServerWindow
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
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.clientListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStripClient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kickClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatContainer = new System.Windows.Forms.SplitContainer();
            this.chatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripChat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageTextBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.clientManagerButton = new System.Windows.Forms.Button();
            this.clientBox = new System.Windows.Forms.GroupBox();
            this.controllBox.SuspendLayout();
            this.contextMenuStripClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatContainer)).BeginInit();
            this.chatContainer.Panel1.SuspendLayout();
            this.chatContainer.Panel2.SuspendLayout();
            this.chatContainer.SuspendLayout();
            this.contextMenuStripChat.SuspendLayout();
            this.clientBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // controllBox
            // 
            this.controllBox.Controls.Add(this.portLabel);
            this.controllBox.Controls.Add(this.portTextBox);
            this.controllBox.Controls.Add(this.startButton);
            this.controllBox.Location = new System.Drawing.Point(12, 12);
            this.controllBox.Name = "controllBox";
            this.controllBox.Size = new System.Drawing.Size(157, 64);
            this.controllBox.TabIndex = 0;
            this.controllBox.TabStop = false;
            this.controllBox.Text = "Start Server";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(3, 16);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(6, 32);
            this.portTextBox.MaximumSize = new System.Drawing.Size(36, 20);
            this.portTextBox.MaxLength = 5;
            this.portTextBox.MinimumSize = new System.Drawing.Size(36, 20);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(36, 20);
            this.portTextBox.TabIndex = 0;
            this.portTextBox.TextChanged += new System.EventHandler(this.PortTextBox_TextChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(48, 16);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(103, 36);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // clientListBox
            // 
            this.clientListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.clientListBox.ContextMenuStrip = this.contextMenuStripClient;
            this.clientListBox.FormattingEnabled = true;
            this.clientListBox.IntegralHeight = false;
            this.clientListBox.Location = new System.Drawing.Point(403, 82);
            this.clientListBox.Name = "clientListBox";
            this.clientListBox.Size = new System.Drawing.Size(125, 389);
            this.clientListBox.Sorted = true;
            this.clientListBox.TabIndex = 4;
            this.clientListBox.SelectedIndexChanged += new System.EventHandler(this.ClientListBox_SelectedIndexChanged);
            // 
            // contextMenuStripClient
            // 
            this.contextMenuStripClient.Name = "contextMenuStripClient";
            this.contextMenuStripClient.Size = new System.Drawing.Size(161, 92);
            this.contextMenuStripClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.addToManagerToolStripMenuItem, this.kickClientToolStripMenuItem, this.banClientToolStripMenuItem});
            // 
            // addToManagerToolStripMenuItem
            // 
            this.addToManagerToolStripMenuItem.Name = "addToManagerToolStripMenuItem";
            this.addToManagerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addToManagerToolStripMenuItem.Text = "Add to Manager";
            this.addToManagerToolStripMenuItem.Click += new System.EventHandler(this.AddToManagerToolStripMenuItem_Click);
            // 
            // kickClientToolStripMenuItem
            // 
            this.kickClientToolStripMenuItem.Name = "kickClientToolStripMenuItem";
            this.kickClientToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.kickClientToolStripMenuItem.Text = "Kick Client";
            this.kickClientToolStripMenuItem.Click += new System.EventHandler(this.KickClientToolStripMenuItem_Click);
            // 
            // banClientToolStripMenuItem
            // 
            this.banClientToolStripMenuItem.Name = "banClientToolStripMenuItem";
            this.banClientToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.banClientToolStripMenuItem.Text = "Ban Client";
            this.banClientToolStripMenuItem.Click += new System.EventHandler(this.BanClientToolStripMenuItem_Click);
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
            this.chatContainer.TabIndex = 3;
            // 
            // chatRichTextBox
            // 
            this.chatRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.chatRichTextBox.ContextMenuStrip = this.contextMenuStripChat;
            this.chatRichTextBox.Location = new System.Drawing.Point(-1, -1);
            this.chatRichTextBox.Name = "chatRichTextBox";
            this.chatRichTextBox.ReadOnly = true;
            this.chatRichTextBox.Size = new System.Drawing.Size(385, 389);
            this.chatRichTextBox.TabIndex = 2;
            this.chatRichTextBox.Text = "";
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
            this.clearChatToolStripMenuItem.Click += new System.EventHandler(this.clearChatToolStripMenuItem_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.messageTextBox.Location = new System.Drawing.Point(-1, -1);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(385, 74);
            this.messageTextBox.TabIndex = 5;
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
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // clientManagerButton
            // 
            this.clientManagerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientManagerButton.Location = new System.Drawing.Point(6, 19);
            this.clientManagerButton.Name = "clientManagerButton";
            this.clientManagerButton.Size = new System.Drawing.Size(113, 36);
            this.clientManagerButton.TabIndex = 1;
            this.clientManagerButton.Text = "Client Manager";
            this.clientManagerButton.UseVisualStyleBackColor = true;
            this.clientManagerButton.Click += new System.EventHandler(this.clientManagerButton_Click);
            // 
            // clientBox
            // 
            this.clientBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientBox.Controls.Add(this.clientManagerButton);
            this.clientBox.Location = new System.Drawing.Point(403, 12);
            this.clientBox.Name = "clientBox";
            this.clientBox.Size = new System.Drawing.Size(125, 64);
            this.clientBox.TabIndex = 2;
            this.clientBox.TabStop = false;
            this.clientBox.Text = "Clients";
            // 
            // ServerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 561);
            this.Controls.Add(this.clientBox);
            this.Controls.Add(this.controllBox);
            this.Controls.Add(this.clientListBox);
            this.Controls.Add(this.chatContainer);
            this.Controls.Add(this.sendButton);
            this.MinimumSize = new System.Drawing.Size(556, 600);
            this.Name = "ServerWindow";
            this.RightToLeftLayout = true;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.ServerWindow_Load);
            this.controllBox.ResumeLayout(false);
            this.controllBox.PerformLayout();
            this.contextMenuStripClient.ResumeLayout(false);
            this.chatContainer.Panel1.ResumeLayout(false);
            this.chatContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chatContainer)).EndInit();
            this.chatContainer.ResumeLayout(false);
            this.contextMenuStripChat.ResumeLayout(false);
            this.clientBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox controllBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ListBox clientListBox;
        private System.Windows.Forms.SplitContainer chatContainer;
        private System.Windows.Forms.RichTextBox chatRichTextBox;
        private System.Windows.Forms.RichTextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChat;
        private System.Windows.Forms.ToolStripMenuItem clearChatToolStripMenuItem;
        private System.Windows.Forms.Button clientManagerButton;
        private System.Windows.Forms.GroupBox clientBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripClient;
        private System.Windows.Forms.ToolStripMenuItem addToManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kickClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem banClientToolStripMenuItem;
    }
}
namespace blockchain{
    partial class Blockchain{
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose( bool disposing ){
            if( disposing && ( components != null ) )
                components.Dispose();
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        private void InitializeComponent(){
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Blockchain));
            this.main_split = new System.Windows.Forms.SplitContainer();
            this.connect_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.other_ip_port_chat = new System.Windows.Forms.TextBox();
            this.your_ip_port_chat = new System.Windows.Forms.TextBox();
            this.log_chain_split = new System.Windows.Forms.SplitContainer();
            this.blockchain_lab = new System.Windows.Forms.Label();
            this.blockchain_chat = new System.Windows.Forms.TextBox();
            this.log_lab = new System.Windows.Forms.Label();
            this.log_chat = new System.Windows.Forms.TextBox();
            this.mine_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.main_split)).BeginInit();
            this.main_split.Panel1.SuspendLayout();
            this.main_split.Panel2.SuspendLayout();
            this.main_split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_chain_split)).BeginInit();
            this.log_chain_split.Panel1.SuspendLayout();
            this.log_chain_split.Panel2.SuspendLayout();
            this.log_chain_split.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_split
            // 
            this.main_split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_split.IsSplitterFixed = true;
            this.main_split.Location = new System.Drawing.Point(0, 0);
            this.main_split.Name = "main_split";
            this.main_split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // main_split.Panel1
            // 
            this.main_split.Panel1.Controls.Add(this.mine_button);
            this.main_split.Panel1.Controls.Add(this.connect_button);
            this.main_split.Panel1.Controls.Add(this.start_button);
            this.main_split.Panel1.Controls.Add(this.other_ip_port_chat);
            this.main_split.Panel1.Controls.Add(this.your_ip_port_chat);
            // 
            // main_split.Panel2
            // 
            this.main_split.Panel2.Controls.Add(this.log_chain_split);
            this.main_split.Size = new System.Drawing.Size(496, 473);
            this.main_split.SplitterDistance = 96;
            this.main_split.TabIndex = 0;
            this.main_split.TabStop = false;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(146, 59);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(75, 22);
            this.connect_button.TabIndex = 0;
            this.connect_button.Text = "CONNECT";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(146, 14);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 22);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "START";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // other_ip_port_chat
            // 
            this.other_ip_port_chat.ForeColor = System.Drawing.Color.Gray;
            this.other_ip_port_chat.Location = new System.Drawing.Point(4, 60);
            this.other_ip_port_chat.Name = "other_ip_port_chat";
            this.other_ip_port_chat.Size = new System.Drawing.Size(135, 20);
            this.other_ip_port_chat.TabIndex = 0;
            this.other_ip_port_chat.Text = "OTHERS IP:PORT HERE";
            this.other_ip_port_chat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.other_ip_port_chat.Enter += new System.EventHandler(this.chat_Enter);
            this.other_ip_port_chat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.other_ip_port_chat_KeyPress);
            this.other_ip_port_chat.Leave += new System.EventHandler(this.chat_Leave);
            // 
            // your_ip_port_chat
            // 
            this.your_ip_port_chat.ForeColor = System.Drawing.Color.Gray;
            this.your_ip_port_chat.Location = new System.Drawing.Point(4, 15);
            this.your_ip_port_chat.Name = "your_ip_port_chat";
            this.your_ip_port_chat.Size = new System.Drawing.Size(135, 20);
            this.your_ip_port_chat.TabIndex = 0;
            this.your_ip_port_chat.Text = "YOUR IP:PORT HERE";
            this.your_ip_port_chat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.your_ip_port_chat.Enter += new System.EventHandler(this.chat_Enter);
            this.your_ip_port_chat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.your_ip_port_chat_KeyPress);
            this.your_ip_port_chat.Leave += new System.EventHandler(this.chat_Leave);
            // 
            // log_chain_split
            // 
            this.log_chain_split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log_chain_split.IsSplitterFixed = true;
            this.log_chain_split.Location = new System.Drawing.Point(0, 0);
            this.log_chain_split.Name = "log_chain_split";
            // 
            // log_chain_split.Panel1
            // 
            this.log_chain_split.Panel1.Controls.Add(this.blockchain_lab);
            this.log_chain_split.Panel1.Controls.Add(this.blockchain_chat);
            // 
            // log_chain_split.Panel2
            // 
            this.log_chain_split.Panel2.Controls.Add(this.log_lab);
            this.log_chain_split.Panel2.Controls.Add(this.log_chat);
            this.log_chain_split.Size = new System.Drawing.Size(496, 373);
            this.log_chain_split.SplitterDistance = 247;
            this.log_chain_split.TabIndex = 0;
            this.log_chain_split.TabStop = false;
            // 
            // blockchain_lab
            // 
            this.blockchain_lab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockchain_lab.AutoSize = true;
            this.blockchain_lab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blockchain_lab.Location = new System.Drawing.Point(4, 4);
            this.blockchain_lab.Name = "blockchain_lab";
            this.blockchain_lab.Size = new System.Drawing.Size(77, 15);
            this.blockchain_lab.TabIndex = 1;
            this.blockchain_lab.Text = "BLOCKCHAIN";
            // 
            // blockchain_chat
            // 
            this.blockchain_chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockchain_chat.Location = new System.Drawing.Point(4, 11);
            this.blockchain_chat.Multiline = true;
            this.blockchain_chat.Name = "blockchain_chat";
            this.blockchain_chat.ReadOnly = true;
            this.blockchain_chat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.blockchain_chat.Size = new System.Drawing.Size(240, 359);
            this.blockchain_chat.TabIndex = 0;
            this.blockchain_chat.TabStop = false;
            this.blockchain_chat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // log_lab
            // 
            this.log_lab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log_lab.AutoSize = true;
            this.log_lab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.log_lab.Location = new System.Drawing.Point(4, 4);
            this.log_lab.Name = "log_lab";
            this.log_lab.Size = new System.Drawing.Size(31, 15);
            this.log_lab.TabIndex = 1;
            this.log_lab.Text = "LOG";
            // 
            // log_chat
            // 
            this.log_chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log_chat.Location = new System.Drawing.Point(4, 11);
            this.log_chat.Multiline = true;
            this.log_chat.Name = "log_chat";
            this.log_chat.ReadOnly = true;
            this.log_chat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log_chat.Size = new System.Drawing.Size(238, 359);
            this.log_chat.TabIndex = 0;
            this.log_chat.TabStop = false;
            this.log_chat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mine_button
            // 
            this.mine_button.Location = new System.Drawing.Point(300, 15);
            this.mine_button.Name = "mine_button";
            this.mine_button.Size = new System.Drawing.Size(150, 75);
            this.mine_button.TabIndex = 0;
            this.mine_button.Text = "MINE";
            this.mine_button.UseVisualStyleBackColor = true;
            this.mine_button.Click += new System.EventHandler(this.mine_button_Click);
            // 
            // Blockchain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 473);
            this.Controls.Add(this.main_split);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Blockchain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "blockchain";
            this.main_split.Panel1.ResumeLayout(false);
            this.main_split.Panel1.PerformLayout();
            this.main_split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_split)).EndInit();
            this.main_split.ResumeLayout(false);
            this.log_chain_split.Panel1.ResumeLayout(false);
            this.log_chain_split.Panel1.PerformLayout();
            this.log_chain_split.Panel2.ResumeLayout(false);
            this.log_chain_split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_chain_split)).EndInit();
            this.log_chain_split.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer main_split;
        private System.Windows.Forms.SplitContainer log_chain_split;
        private System.Windows.Forms.Label log_lab;
        private System.Windows.Forms.TextBox log_chat;
        private System.Windows.Forms.TextBox blockchain_chat;
        private System.Windows.Forms.Label blockchain_lab;
        private System.Windows.Forms.TextBox your_ip_port_chat;
        private System.Windows.Forms.TextBox other_ip_port_chat;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Button mine_button;
    }
}


namespace chatroomserver
{
    partial class FormChatServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.labPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.liboxOnLine = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labIP
            // 
            this.labIP.AutoSize = true;
            this.labIP.Location = new System.Drawing.Point(227, 24);
            this.labIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labIP.Name = "labIP";
            this.labIP.Size = new System.Drawing.Size(23, 15);
            this.labIP.TabIndex = 0;
            this.labIP.Text = "IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(257, 20);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(165, 25);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "127.0.0.1";

            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(457, 25);
            this.labPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(39, 15);
            this.labPort.TabIndex = 0;
            this.labPort.Text = "port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(504, 20);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(149, 25);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "50001";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(708, 16);
            this.btnListen.Margin = new System.Windows.Forms.Padding(4);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(100, 29);
            this.btnListen.TabIndex = 2;
            this.btnListen.Text = "open";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(257, 54);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(565, 300);
            this.txtMsg.TabIndex = 3;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "listOfUser";
            // 
            // liboxOnLine
            // 
            this.liboxOnLine.FormattingEnabled = true;
            this.liboxOnLine.ItemHeight = 15;
            this.liboxOnLine.Location = new System.Drawing.Point(35, 54);
            this.liboxOnLine.Margin = new System.Windows.Forms.Padding(4);
            this.liboxOnLine.Name = "liboxOnLine";
            this.liboxOnLine.Size = new System.Drawing.Size(159, 304);
            this.liboxOnLine.TabIndex = 8;
            // 
            // FormChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 425);
            this.Controls.Add(this.liboxOnLine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.labPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.labIP);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormChatServer";
            this.Text = "server";

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox liboxOnLine;
    }
}


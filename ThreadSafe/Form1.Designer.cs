namespace ThreadSafe
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Stop = new System.Windows.Forms.Button();
            this.L = new System.Windows.Forms.Label();
            this.CountertBox1 = new System.Windows.Forms.TextBox();
            this.CountertBox2 = new System.Windows.Forms.TextBox();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(152, 139);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(100, 50);
            this.Stop.TabIndex = 0;
            this.Stop.Text = "终止线程";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // L
            // 
            this.L.AutoSize = true;
            this.L.Location = new System.Drawing.Point(73, 38);
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(233, 84);
            this.L.TabIndex = 1;
            this.L.Text = "线程的计数值:\r\n\r\n\r\n线程运行状态:\r\n\r\n对控件采用线程安全调用的程序执行速度比\r\n采用非线程安全调用的程序快得多";
            // 
            // CountertBox1
            // 
            this.CountertBox1.Location = new System.Drawing.Point(162, 35);
            this.CountertBox1.Name = "CountertBox1";
            this.CountertBox1.Size = new System.Drawing.Size(100, 21);
            this.CountertBox1.TabIndex = 2;
            // 
            // CountertBox2
            // 
            this.CountertBox2.Location = new System.Drawing.Point(162, 65);
            this.CountertBox2.Name = "CountertBox2";
            this.CountertBox2.Size = new System.Drawing.Size(100, 21);
            this.CountertBox2.TabIndex = 2;
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.CountertBox2);
            this.Controls.Add(this.CountertBox1);
            this.Controls.Add(this.L);
            this.Controls.Add(this.Stop);
            this.Name = "Form1";
            this.Text = "线程安全";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Label L;
        private System.Windows.Forms.TextBox CountertBox1;
        private System.Windows.Forms.TextBox CountertBox2;
        private System.ComponentModel.BackgroundWorker BackgroundWorker1;
    }
}


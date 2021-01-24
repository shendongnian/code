    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.liveLabel = new System.Windows.Forms.Label();
            this.deadLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Live: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dead: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Status: ";
            // 
            // liveLabel
            // 
            this.liveLabel.AutoSize = true;
            this.liveLabel.Location = new System.Drawing.Point(123, 110);
            this.liveLabel.Name = "liveLabel";
            this.liveLabel.Size = new System.Drawing.Size(0, 32);
            this.liveLabel.TabIndex = 1;
            // 
            // deadLabel
            // 
            this.deadLabel.AutoSize = true;
            this.deadLabel.Location = new System.Drawing.Point(123, 142);
            this.deadLabel.Name = "deadLabel";
            this.deadLabel.Size = new System.Drawing.Size(0, 32);
            this.deadLabel.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(123, 174);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 32);
            this.statusLabel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 780);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.deadLabel);
            this.Controls.Add(this.liveLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label liveLabel;
        private System.Windows.Forms.Label deadLabel;
        private System.Windows.Forms.Label statusLabel;
    }

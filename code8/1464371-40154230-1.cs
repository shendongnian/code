    namespace WindowsFormsApplication2
    {
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
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.comboBox1 = new System.Windows.Forms.ComboBox();
                this.comboBox2 = new System.Windows.Forms.ComboBox();
                this.comboBox3 = new System.Windows.Forms.ComboBox();
                this.comboBox4 = new System.Windows.Forms.ComboBox();
                this.groupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // groupBox1
                // 
                this.groupBox1.BackColor = System.Drawing.Color.Transparent;
                this.groupBox1.Controls.Add(this.comboBox4);
                this.groupBox1.Controls.Add(this.comboBox3);
                this.groupBox1.Controls.Add(this.comboBox2);
                this.groupBox1.Controls.Add(this.comboBox1);
                this.groupBox1.Location = new System.Drawing.Point(33, 36);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(193, 184);
                this.groupBox1.TabIndex = 0;
                this.groupBox1.TabStop = false;
                this.groupBox1.Text = "groupBox1";
                // 
                // comboBox1
                // 
                this.comboBox1.FormattingEnabled = true;
                this.comboBox1.Location = new System.Drawing.Point(36, 40);
                this.comboBox1.Name = "comboBox1";
                this.comboBox1.Size = new System.Drawing.Size(121, 21);
                this.comboBox1.TabIndex = 0;
                // 
                // comboBox2
                // 
                this.comboBox2.FormattingEnabled = true;
                this.comboBox2.Location = new System.Drawing.Point(36, 67);
                this.comboBox2.Name = "comboBox2";
                this.comboBox2.Size = new System.Drawing.Size(121, 21);
                this.comboBox2.TabIndex = 1;
                // 
                // comboBox3
                // 
                this.comboBox3.FormattingEnabled = true;
                this.comboBox3.Location = new System.Drawing.Point(36, 94);
                this.comboBox3.Name = "comboBox3";
                this.comboBox3.Size = new System.Drawing.Size(121, 21);
                this.comboBox3.TabIndex = 1;
                // 
                // comboBox4
                // 
                this.comboBox4.FormattingEnabled = true;
                this.comboBox4.Location = new System.Drawing.Point(36, 121);
                this.comboBox4.Name = "comboBox4";
                this.comboBox4.Size = new System.Drawing.Size(121, 21);
                this.comboBox4.TabIndex = 1;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 261);
                this.Controls.Add(this.groupBox1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                this.groupBox1.ResumeLayout(false);
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private System.Windows.Forms.GroupBox groupBox1;
            private System.Windows.Forms.ComboBox comboBox1;
            private System.Windows.Forms.ComboBox comboBox4;
            private System.Windows.Forms.ComboBox comboBox3;
            private System.Windows.Forms.ComboBox comboBox2;
        }
    }

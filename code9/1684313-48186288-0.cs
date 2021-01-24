    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkTop = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkBottom = new System.Windows.Forms.CheckBox();
            this.chkRight = new System.Windows.Forms.CheckBox();
            this.chkLeft = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkLeft);
            this.panel1.Controls.Add(this.chkRight);
            this.panel1.Controls.Add(this.chkBottom);
            this.panel1.Controls.Add(this.chkTop);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(43, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 148);
            this.panel1.TabIndex = 0;
            // 
            // chkTop
            // 
            this.chkTop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkTop.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTop.Location = new System.Drawing.Point(95, 2);
            this.chkTop.Name = "chkTop";
            this.chkTop.Size = new System.Drawing.Size(17, 58);
            this.chkTop.TabIndex = 1;
            this.chkTop.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(73, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // chkBottom
            // 
            this.chkBottom.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkBottom.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBottom.Location = new System.Drawing.Point(95, 85);
            this.chkBottom.Name = "chkBottom";
            this.chkBottom.Size = new System.Drawing.Size(17, 59);
            this.chkBottom.TabIndex = 2;
            this.chkBottom.UseVisualStyleBackColor = false;
            // 
            // chkRight
            // 
            this.chkRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkRight.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRight.Location = new System.Drawing.Point(132, 64);
            this.chkRight.Name = "chkRight";
            this.chkRight.Size = new System.Drawing.Size(71, 17);
            this.chkRight.TabIndex = 3;
            this.chkRight.UseVisualStyleBackColor = false;
            // 
            // chkLeft
            // 
            this.chkLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkLeft.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLeft.Location = new System.Drawing.Point(1, 63);
            this.chkLeft.Name = "chkLeft";
            this.chkLeft.Size = new System.Drawing.Size(71, 17);
            this.chkLeft.TabIndex = 4;
            this.chkLeft.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkTop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkLeft;
        private System.Windows.Forms.CheckBox chkRight;
        private System.Windows.Forms.CheckBox chkBottom;
    }

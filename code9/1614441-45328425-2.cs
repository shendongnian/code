    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WorkingSolution
    {
        public class Form1 : Form
        {
            private int _NumOfTicks;
            public Form1()
            {
                InitializeComponent();
            }
            private void label1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    _NumOfTicks = 0;
                    click.Enabled = true;
                }
            }
            private void label1_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    click.Enabled = false;
                }
            }
            private void click_Tick(object sender, EventArgs e)
            {
                this.lblTickCount.Text = _NumOfTicks.ToString();
                _NumOfTicks++;
            }
            #region designer code
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
                this.click = new System.Windows.Forms.Timer(this.components);
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.lblTickCount = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // click
                // 
                this.click.Interval = 1000;
                this.click.Tick += new System.EventHandler(this.click_Tick);
                // 
                // label1
                // 
                this.label1.BackColor = System.Drawing.Color.Firebrick;
                this.label1.ForeColor = System.Drawing.Color.White;
                this.label1.Location = new System.Drawing.Point(37, 24);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(207, 78);
                this.label1.TabIndex = 0;
                this.label1.Text = "Hold left mouse button over me";
                this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
                this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(37, 149);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(109, 13);
                this.label2.TabIndex = 1;
                this.label2.Text = "Number of timer ticks:";
                // 
                // lblTickCount
                // 
                this.lblTickCount.AutoSize = true;
                this.lblTickCount.Location = new System.Drawing.Point(152, 149);
                this.lblTickCount.Name = "lblTickCount";
                this.lblTickCount.Size = new System.Drawing.Size(0, 13);
                this.lblTickCount.TabIndex = 2;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.lblTickCount);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            #endregion
            private System.Windows.Forms.Timer click;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label lblTickCount;
            #endregion designer code
        }
    }

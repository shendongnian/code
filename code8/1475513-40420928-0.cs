    //frmResizing.cs
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class frmResizing : Form
        {
            public frmResizing()
            {
                InitializeComponent();
            }
        }
    }
    //frmResizing.Designer.cs code
    namespace WindowsFormsApplication1
    {
        partial class frmResizing
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
                this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                this.panel1 = new System.Windows.Forms.Panel();
                this.pictureBox4 = new System.Windows.Forms.PictureBox();
                this.pictureBox3 = new System.Windows.Forms.PictureBox();
                this.pictureBox2 = new System.Windows.Forms.PictureBox();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.tableLayoutPanel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // tableLayoutPanel1
                // 
                this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
                this.tableLayoutPanel1.ColumnCount = 2;
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 1, 1);
                this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 0, 1);
                this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
                this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
                this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 1);
                this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                this.tableLayoutPanel1.RowCount = 2;
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 561);
                this.tableLayoutPanel1.TabIndex = 0;
                // 
                // panel1
                // 
                this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
                this.panel1.BackColor = System.Drawing.Color.Red;
                this.panel1.Location = new System.Drawing.Point(553, 1);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(107, 561);
                this.panel1.TabIndex = 1;
                // 
                // pictureBox4
                // 
                this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pictureBox4.Image = global::WindowsFormsApplication1.Properties.Resources.download;
                this.pictureBox4.Location = new System.Drawing.Point(275, 283);
                this.pictureBox4.Name = "pictureBox4";
                this.pictureBox4.Size = new System.Drawing.Size(266, 275);
                this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox4.TabIndex = 3;
                this.pictureBox4.TabStop = false;
                // 
                // pictureBox3
                // 
                this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pictureBox3.Image = global::WindowsFormsApplication1.Properties.Resources.pizza_page;
                this.pictureBox3.Location = new System.Drawing.Point(3, 283);
                this.pictureBox3.Name = "pictureBox3";
                this.pictureBox3.Size = new System.Drawing.Size(266, 275);
                this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox3.TabIndex = 2;
                this.pictureBox3.TabStop = false;
                // 
                // pictureBox2
                // 
                this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.images;
                this.pictureBox2.Location = new System.Drawing.Point(275, 3);
                this.pictureBox2.Name = "pictureBox2";
                this.pictureBox2.Size = new System.Drawing.Size(266, 274);
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox2.TabIndex = 1;
                this.pictureBox2.TabStop = false;
                // 
                // pictureBox1
                // 
                this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.download__1_;
                this.pictureBox1.Location = new System.Drawing.Point(3, 3);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(266, 274);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox1.TabIndex = 0;
                this.pictureBox1.TabStop = false;
                // 
                // Form2
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(660, 562);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.tableLayoutPanel1);
                this.Name = "Form2";
                this.Text = "Form2";
                this.tableLayoutPanel1.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            private System.Windows.Forms.PictureBox pictureBox4;
            private System.Windows.Forms.PictureBox pictureBox3;
            private System.Windows.Forms.PictureBox pictureBox2;
            private System.Windows.Forms.PictureBox pictureBox1;
            private System.Windows.Forms.Panel panel1;
        }
    }

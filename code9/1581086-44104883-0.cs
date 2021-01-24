    Form1 : (Form1.cs)
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace BankDetails_Test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var uc = new BankDtls();
                uc.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
                //uc.lblBankName.Text = detail.BankName;
                //uc.lblLowerLimit.Text = detail.LLimit;
                //uc.lblHigherLimit.Text = detail.HLimit;
                //var temp = tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1];
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                tableLayoutPanel1.Controls.Add(uc, 0, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.SetColumnSpan(uc, 3);
                this.Height += 40;
                this.MinimumSize = new Size(this.Width, this.Height);
                tableLayoutPanel1.RowCount++;
            }
        }
    }
    
    
    Form1 ( Designer.cs )
    namespace BankDetails_Test
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
                this.button1 = new System.Windows.Forms.Button();
                this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.tableLayoutPanel1.SuspendLayout();
                this.SuspendLayout();
                // 
                // button1
                // 
                this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button1.Location = new System.Drawing.Point(306, 42);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 23);
                this.button1.TabIndex = 0;
                this.button1.Text = "Add Another";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // tableLayoutPanel1
                // 
                this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
                this.tableLayoutPanel1.ColumnCount = 3;
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
                this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
                this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
                this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
                this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
                this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                this.tableLayoutPanel1.RowCount = 2;
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
                this.tableLayoutPanel1.Size = new System.Drawing.Size(376, 31);
                this.tableLayoutPanel1.TabIndex = 1;
                // 
                // label1
                // 
                this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
                this.label1.AutoSize = true;
                this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label1.Location = new System.Drawing.Point(5, 5);
                this.label1.Margin = new System.Windows.Forms.Padding(5);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(115, 20);
                this.label1.TabIndex = 0;
                this.label1.Text = "Bank Name";
                this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // label2
                // 
                this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
                this.label2.AutoSize = true;
                this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label2.Location = new System.Drawing.Point(130, 5);
                this.label2.Margin = new System.Windows.Forms.Padding(5);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(115, 20);
                this.label2.TabIndex = 1;
                this.label2.Text = "Lower Margin";
                this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // label3
                // 
                this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
                this.label3.AutoSize = true;
                this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label3.Location = new System.Drawing.Point(255, 5);
                this.label3.Margin = new System.Windows.Forms.Padding(5);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(116, 20);
                this.label3.TabIndex = 2;
                this.label3.Text = "Higher Margin";
                this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(393, 70);
                this.Controls.Add(this.tableLayoutPanel1);
                this.Controls.Add(this.button1);
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "Form1";
                this.Text = "Form1";
                this.tableLayoutPanel1.ResumeLayout(false);
                this.tableLayoutPanel1.PerformLayout();
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Label label2;
        }
    }
    
    
    
    BankDtls - UserControl (BankDtls.Designer.cs)
    namespace BankDetails_Test
    {
        partial class BankDtls
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
    
            #region Component Designer generated code
    
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                this.comboBox1 = new System.Windows.Forms.ComboBox();
                this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
                this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
                this.tableLayoutPanel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
                this.SuspendLayout();
                // 
                // tableLayoutPanel1
                // 
                this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
                this.tableLayoutPanel1.ColumnCount = 3;
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                this.tableLayoutPanel1.Controls.Add(this.numericUpDown2, 2, 0);
                this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 0);
                this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 1, 0);
                this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
                this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                this.tableLayoutPanel1.RowCount = 1;
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 31);
                this.tableLayoutPanel1.TabIndex = 0;
                // 
                // comboBox1
                // 
                this.comboBox1.FormattingEnabled = true;
                this.comboBox1.Items.AddRange(new object[] {
                "Bank ABC",
                "Bank XYZ",
                "Bank DSH"});
                this.comboBox1.Location = new System.Drawing.Point(3, 3);
                this.comboBox1.Name = "comboBox1";
                this.comboBox1.Size = new System.Drawing.Size(104, 21);
                this.comboBox1.TabIndex = 0;
                // 
                // numericUpDown1
                // 
                this.numericUpDown1.Location = new System.Drawing.Point(113, 3);
                this.numericUpDown1.Name = "numericUpDown1";
                this.numericUpDown1.Size = new System.Drawing.Size(104, 20);
                this.numericUpDown1.TabIndex = 1;
                // 
                // numericUpDown2
                // 
                this.numericUpDown2.Location = new System.Drawing.Point(223, 3);
                this.numericUpDown2.Name = "numericUpDown2";
                this.numericUpDown2.Size = new System.Drawing.Size(104, 20);
                this.numericUpDown2.TabIndex = 2;
                // 
                // BankDtls
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Controls.Add(this.tableLayoutPanel1);
                this.Name = "BankDtls";
                this.Size = new System.Drawing.Size(340, 39);
                this.tableLayoutPanel1.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            private System.Windows.Forms.NumericUpDown numericUpDown2;
            private System.Windows.Forms.ComboBox comboBox1;
            private System.Windows.Forms.NumericUpDown numericUpDown1;
        }
    }

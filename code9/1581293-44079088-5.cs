    namespace ExecuteText
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                this.TextBox = new System.Windows.Forms.RichTextBox();
                this.Block = new System.Windows.Forms.PictureBox();
                this.Run = new System.Windows.Forms.Button();
                this.ErrorTextBox = new System.Windows.Forms.RichTextBox();
                this.PositionTextBox = new System.Windows.Forms.RichTextBox();
                ((System.ComponentModel.ISupportInitialize)(this.Block)).BeginInit();
                this.SuspendLayout();
                // 
                // TextBox
                // 
                this.TextBox.Location = new System.Drawing.Point(12, 43);
                this.TextBox.Name = "TextBox";
                this.TextBox.Size = new System.Drawing.Size(400, 605);
                this.TextBox.TabIndex = 0;
                this.TextBox.Text = resources.GetString("TextBox.Text");
                this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
                // 
                // Block
                // 
                this.Block.BackColor = System.Drawing.Color.DodgerBlue;
                this.Block.Location = new System.Drawing.Point(591, 314);
                this.Block.Name = "Block";
                this.Block.Size = new System.Drawing.Size(52, 50);
                this.Block.TabIndex = 1;
                this.Block.TabStop = false;
                // 
                // Run
                // 
                this.Run.Location = new System.Drawing.Point(12, 12);
                this.Run.Name = "Run";
                this.Run.Size = new System.Drawing.Size(75, 23);
                this.Run.TabIndex = 2;
                this.Run.Text = "Run";
                this.Run.UseVisualStyleBackColor = true;
                this.Run.Click += new System.EventHandler(this.Run_Click);
                // 
                // ErrorTextBox
                // 
                this.ErrorTextBox.Location = new System.Drawing.Point(12, 665);
                this.ErrorTextBox.Name = "ErrorTextBox";
                this.ErrorTextBox.Size = new System.Drawing.Size(747, 96);
                this.ErrorTextBox.TabIndex = 3;
                this.ErrorTextBox.Text = "";
                // 
                // PositionTextBox
                // 
                this.PositionTextBox.Location = new System.Drawing.Point(418, 43);
                this.PositionTextBox.Name = "PositionTextBox";
                this.PositionTextBox.Size = new System.Drawing.Size(341, 44);
                this.PositionTextBox.TabIndex = 4;
                this.PositionTextBox.Text = "";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(771, 773);
                this.Controls.Add(this.PositionTextBox);
                this.Controls.Add(this.ErrorTextBox);
                this.Controls.Add(this.Run);
                this.Controls.Add(this.Block);
                this.Controls.Add(this.TextBox);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                ((System.ComponentModel.ISupportInitialize)(this.Block)).EndInit();
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private System.Windows.Forms.RichTextBox TextBox;
            private System.Windows.Forms.Button Run;
            public System.Windows.Forms.PictureBox Block;
            private System.Windows.Forms.RichTextBox ErrorTextBox;
            private System.Windows.Forms.RichTextBox PositionTextBox;
        }
    }

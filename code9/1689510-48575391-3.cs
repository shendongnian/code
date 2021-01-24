    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            private System.Windows.Forms.TextBox txtGap;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label lblClickedOn;
            private System.Windows.Forms.TextBox txtTarget;
    
            private void txtTarget_MouseDown(object sender, MouseEventArgs e)
            {
                int index = txtTarget.GetCharIndexFromPosition(e.Location);
                Point pt = txtTarget.GetPositionFromCharIndex(index);
    
                //Debugging help
                lblClickedOn.Text = index.ToString();
                
                txtGap.Visible = false;
                if (txtTarget.Text[index] == (char)'_')
                {
                    //Work out the left co-ordinate for the textbox by checking the number of underscores prior
                    int priorLetterToUnderscore = 0;
                    for (int i = index - 1; i > 0; i--)
                    {
                        if (txtTarget.Text[i] != (char)'_')
                        {
                            priorLetterToUnderscore = i + 1;
                            break;
                        }
                    }
    
                    int afterLetterToUnderscore = 0;
                    for (int i = index + 1; i > 0; i++)
                    {
                        if (txtTarget.Text[i] != (char)'_')
                        {
                            afterLetterToUnderscore = i;
                            break;
                        }
                    }
    
                    //It was an underscore clicked on
                    if (priorLetterToUnderscore > 0 || afterLetterToUnderscore > 0)
                    {
                        //Measure the characters width earlier than the priorLetterToUnderscore
                        pt = txtTarget.GetPositionFromCharIndex(priorLetterToUnderscore);
                        int left = pt.X + txtTarget.Left;
    
                        pt = txtTarget.GetPositionFromCharIndex(afterLetterToUnderscore);
                        int width = pt.X + txtTarget.Left - left;
    
                        //Check the row/line we are on
                        SizeF textSize = this.txtTarget.CreateGraphics().MeasureString("A", this.txtTarget.Font, this.txtTarget.Width);
                        int line = pt.Y / (int)textSize.Height;
                        txtGap.Location = new Point(left, txtTarget.Top + (line * (int)textSize.Height));
                        txtGap.Width = width;
                        txtGap.Text = string.Empty;
                        txtGap.Visible = true;
                    }
                }
            }
    
            private void Form1_Click(object sender, EventArgs e)
            {
                txtGap.Visible = false;
            }
    
            public Form1()
            {
                this.txtGap = new System.Windows.Forms.TextBox();
                this.label2 = new System.Windows.Forms.Label();
                this.lblClickedOn = new System.Windows.Forms.Label();
                this.txtTarget = new System.Windows.Forms.TextBox();
                this.SuspendLayout();
                // 
                // txtGap
                // 
                this.txtGap.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtGap.Location = new System.Drawing.Point(206, 43);
                this.txtGap.Name = "txtGap";
                this.txtGap.Size = new System.Drawing.Size(25, 20);
                this.txtGap.TabIndex = 1;
                this.txtGap.Text = "ump";
                this.txtGap.Visible = false;
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(22, 52);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(84, 13);
                this.label2.TabIndex = 2;
                this.label2.Text = "Char clicked on:";
                // 
                // lblClickedOn
                // 
                this.lblClickedOn.AutoSize = true;
                this.lblClickedOn.Location = new System.Drawing.Point(113, 52);
                this.lblClickedOn.Name = "lblClickedOn";
                this.lblClickedOn.Size = new System.Drawing.Size(13, 13);
                this.lblClickedOn.TabIndex = 3;
                this.lblClickedOn.Text = "_";
                // 
                // txtTarget
                // 
                this.txtTarget.BackColor = System.Drawing.SystemColors.Menu;
                this.txtTarget.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.txtTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTarget.Location = new System.Drawing.Point(22, 21);
                this.txtTarget.Name = "txtTarget";
                this.txtTarget.ReadOnly = true;
                this.txtTarget.Size = new System.Drawing.Size(317, 16);
                this.txtTarget.TabIndex = 4;
                this.txtTarget.Text = "The quick brown fox j___ed over the l__y hound";
                this.txtTarget.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtTarget_MouseDown);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(394, 95);
                this.Controls.Add(this.txtGap);
                this.Controls.Add(this.txtTarget);
                this.Controls.Add(this.lblClickedOn);
                this.Controls.Add(this.label2);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Click += new System.EventHandler(this.Form1_Click);
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }        
    }

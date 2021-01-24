    // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 164);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        
        private void HelloButton_Click(object sender, EventArgs e)
        {
            translationLabel.Text = "Salve";
        }
        private void HappyButton_Click(object sender, EventArgs e)
        {
            translationLabel.Text = "Laeta";
        }
        private void GoodnightButton_Click(object sender, EventArgs e)
        {
            translationLabel.Text = "Bonum nox";
        }
    }
}

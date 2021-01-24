        private void toggleCheckBox_Click(object sender, EventArgs e)
        {
            theGraph.Visible = toggleCheckBox.Checked;
            // automatically resize the form
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.OnResize(e);
            var NewSize = new System.Drawing.Size(this.Width, this.Height);
            // this will force the form back to its original size
            // allowing the user to adjust the form 
            this.AutoSize = false; 
            // force the form back to its new size
            this.Size = newSize;
        }

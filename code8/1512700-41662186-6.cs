        public MainForm()
        {
            ...
            this.richTextBox.LostFocus += RichTextBox_LostFocus;
        }
       
        private void RichTextBox_LostFocus(object sender, EventArgs e)
        {
            this._previousSelection = null;
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.Z))
            {
                while (this.richTextBox1.CanUndo &&
                    this.richTextBox1.UndoActionName.Equals("Unknown"))
                {
                    this.richTextBox1.Undo();
                }
            }
            else if (e.Control && (e.KeyCode == Keys.V))
            {
                HighLightText();
                e.Handled = true;
            }
            else if (e.Shift && (e.KeyCode == Keys.Insert))
            {
                HighLightText();
                e.Handled = true;
            }  
        }
 
        private void HighLightText()
        {
            int iCount = 0;
            int iWordPos = 0;
            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Text);
            this.richTextBox1.Paste(myFormat);
            string[] strSplitText = this.richTextBox1.Text.Split(' ');
            foreach (string strWord in strSplitText)
            {
                if (iCount % 2 == 0)
                {
                    this.richTextBox1.Select(iWordPos, strWord.Length);
                    this.richTextBox1.SelectionColor = Color.Blue;
                }
                else
                {
                    this.richTextBox1.Select(iWordPos, strWord.Length);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
                iWordPos += strWord.Length + 1;
                iCount++;
            }
            this.richTextBox1.Select(this.richTextBox1.Text.Length - 1, 0);
        }
 ---------------------------------------------------------------------------------------------------------------  
  

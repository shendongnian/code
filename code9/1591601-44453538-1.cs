        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            var pos = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
            button2.Location = new Point(richTextBox1.Left - button2.Width - 2, pos.Y + richTextBox1.Top);
        }

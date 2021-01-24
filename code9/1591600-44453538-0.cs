        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            var pos = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
            if (pos.X > button2.Width + 4)
            {
                if (button2.Parent != richTextBox1)
                {
                    button2.Parent.Controls.Remove(button2);
                    richTextBox1.Controls.Add(button2);
                }
                button2.Location = new Point(pos.X - button2.Width - 2, pos.Y);
            }
            else
            {
                if (button2.Parent == richTextBox1)
                {
                    button2.Parent.Controls.Remove(button2);
                    richTextBox1.Parent.Controls.Add(button2);
                }
                button2.Location = new Point(richTextBox1.Left - button2.Width - 2, pos.Y + richTextBox1.Top);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.White;
            index = richTextBox1.Find(textBox1.Text, index + 1, richTextBox1.TextLength, RichTextBoxFinds.None);
            richTextBox1.SelectionBackColor = Color.Yellow;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.White;
            index = richTextBox1.Find(textBox1.Text, 0, index - 1, RichTextBoxFinds.Reverse);
            richTextBox1.SelectionBackColor = Color.Yellow;
        }

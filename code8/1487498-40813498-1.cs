        int selectionStart = 0;
        int selectionStop = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.White;
            selectionStart = richTextBox1.Find(textBox1.Text, selectionStop, richTextBox1.TextLength, RichTextBoxFinds.None);
            selectionStop = selectionStart + textBox1.Text.Length;
            richTextBox1.SelectionBackColor = Color.Yellow;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.White;
            selectionStart = richTextBox1.Find(textBox1.Text, 0, selectionStart, RichTextBoxFinds.Reverse);
            selectionStop = selectionStart + textBox1.Text.Length;
            richTextBox1.SelectionBackColor = Color.Yellow;
        }

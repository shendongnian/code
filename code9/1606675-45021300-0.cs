    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        // Color all numeric characters red:
        for(int i = 0; i < richTextBox1.TextLength; i++)
        {
            var character = richTextBox1.Text[i];
            if (!char.IsNumber(character)) continue;
            richTextBox1.SelectionStart = i;
            richTextBox1.SelectionLength = 1;
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionColor = Color.Black;
        }
    }

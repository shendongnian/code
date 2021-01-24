    private void richTextBox1_TextChanged(object sender, EventArgs e)
    { 
        richTextBox1.Select(0,richTextBox1.Text.Length -1);
        richTextBox1.SelectionColor = Color.Black;
        richTextBox1.SelectionStart = 0;
        
        this.CheckKeyword("html", Color.Green, 0);
        this.CheckKeyword("head", Color.Green, 0);
        if (richTextBox1.Text.Contains(words) == false)
        {
            this.richTextBox1.SelectionColor = Color.Black;
        }
    }

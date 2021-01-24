    private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
    {
        var textIndex = richTextBox1.GetCharIndexFromPosition(e.Location);
        if (richTextBox1.Text.Length > 0)
            label1.Text = richTextBox1.Text[textIndex].ToString();
    }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        if (richTextBox1.Text.Last() == '(')
        {
            // remember the start index
            startIndex = richTextBox1.Text.Length-1; // -1 will take the "(" also to be formatted
            startFormatting = true; // now you can start formatting with the cool font
        }
        if (richTextBox1.Text.Last() == ')')
        {
            MessageBox.Show("found end ");
            startIndex = richTextBox1.Text.Length;
            startFormatting = false;   // now you can proceed to format with boring default font             
        }
        charCount++;
        if (startFormatting)
        {
            FormatMiddleText(startIndex, charCount, font, Color.Red);
        }
        else
        {
            FormatMiddleText(startIndex, charCount, DefaultFont, Color.Black);
        }
    }

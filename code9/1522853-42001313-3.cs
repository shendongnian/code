    void TextBox_TextChanged(object sender, EventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox != null)
        {
            textBox.Text = textBox.Text.Trim();
            if (textBox.Text.Length > 1 && textBox.Text[0] == '0')
            {
                textBox.Text = textBox.Text.Substring(1, textBox.Text.Length - 1);
            }
            else
            {
                textBox.Text = "";
            }
        }
    }

    void TextBox_TextChanged(object sender, EventArgs e)
    {
        if ((sender as TextBox).Text[0] == '0')
        {
            e.Handled = true;
        }
    }

    private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
    {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[1-9]"))
            {
                e.Handled = true;
            }
    }

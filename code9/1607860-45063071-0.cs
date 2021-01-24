    char[] ca = textBox2.Text.ToCharArray();
    foreach (char c in ca)
    {
        if(char.IsDigit(c))
        {
            MessageBox.Show("Non-integer detected in text box.");
            EndInvoke(null);
        }
    }

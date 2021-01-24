    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
       if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Space)
       {
           char _keypress = char.IsControl(e.KeyChar) ? (char)(e.KeyChar ^ 64) : e.KeyChar;
           e.Handled = !char.IsLetterOrDigit(_keypress) && !char.IsPunctuation(_keypress);
       }
    }

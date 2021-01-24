    Regex _KeyFilter = new Regex(@"^[a-zA-Z0-9.,]");
    
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
       if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Space)
       {
            e.Handled = !_KeyFilter.IsMatch((char.IsControl(e.KeyChar)
                                          ? (char)(e.KeyChar ^ 64) 
                                          : e.KeyChar).ToString());
       }
    }

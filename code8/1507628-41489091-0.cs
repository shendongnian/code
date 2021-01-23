    void Control_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!Char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

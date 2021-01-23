    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
        {
            if (!textBox1.AcceptsReturn)
            {
                button1.PerformClick();
                e.Handled = true;
            }
        }
    }

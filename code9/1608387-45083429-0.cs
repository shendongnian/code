    private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsDigit(e.KeyChar))
        {
            SendKeys.Send("{ENTER}");
            numericUpDown1.Select();
            SendKeys.Send("{END}");
        }
    }

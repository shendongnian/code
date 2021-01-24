    public void setCheckBox(CheckBox chk, TextBox txt)
    {
        if (chk.Checked)
        {
            txt.Enabled = true;
            txt.Focus();
        }
        else
        {
            txt.Enabled = false;
            txt.Text = "0";
        }
    }

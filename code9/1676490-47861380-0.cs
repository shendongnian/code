    public void ClearTextBox(Control root)
    {
        foreach (Control ctrl in root.Controls)
        {
            ClearTextBox(ctrl);
            if (ctrl is TextBox)
            {
                (TextBox)ctrl.Text = string.Empty;
            }
        }
    }

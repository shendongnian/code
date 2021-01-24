    public void SetReadOnly(bool readOnly)
    {
        foreach (TabPage tab in tabControl.TabPages)
        {
            foreach (Control c in tab.Controls)
            {
                 if (c is TextBox)
                 {
                     ((TextBox)c).ReadOnly = readOnly;
                 }
                 else
                 {
                     // All controls support this property
                     c.Enabled = !readOnly;
                 }
            }
        }
    }

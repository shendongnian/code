    public void SetReadOnly(bool readOnly)
    {
        foreach (var tab in tabControl.TabPages)
        {
            foreach (var c in tab.Controls)
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

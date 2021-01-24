    public void DisableControls(Control con)
    {
        foreach (Control c in con.Controls)
        {
            DisableControls(c);
        }
    
        // This can also be used to disable other types of controls
        if (con is TextBox) con.Enabled = false;
    }

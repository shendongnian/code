    // This will only disable all the textboxs
    public void DisableControls(Control con)
    {
        foreach (TextBox c in con.Controls.OfType<TextBox>())
        {
            c.Enabled = false;
        }
    }

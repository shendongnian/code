    private void doReset()
    {
        foreach (Control c in this.Controls)
        {
            if (c.GetType() == typeof(Button))
            {
                c.Enabled = true;
            }
            else if (c.GetType() == typeof(Label))
            {
                c.Visible = false;
            }
        }
    }

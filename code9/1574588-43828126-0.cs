    public static void disableButtons(Control parent)
    {
        foreach (Control c in parent.Controls)
            if (c.GetType() == typeof(Button))
                c.Enabled = false;
            else
                disableButtons(c);
    }

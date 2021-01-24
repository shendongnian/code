    private void SetColor( List<Control> control)
    {
        foreach (Control c in control)
        {
           if (c.Name.StartsWith("SC")) { c.ForeColor = Color.FromArgb(rr, gg, bb); }
         }
    }

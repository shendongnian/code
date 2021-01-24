    foreach (Control c in GetAllControls(this))
    {
        Button b = c as Button;
        if (b != null)
        {
            b.FlatAppearance.MouseOverBackColor = b.BackColor;
            b.FlatAppearance.MouseDownBackColor = b.BackColor;
            b.FlatStyle = FlatStyle.Flat;
        }
    }

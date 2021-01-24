    List<UserControl> a = new List<UserControl>{ drives1, ipAdd1, spotify1, timeAndDate1, activeWindow1, reminders11, weather1 };
    foreach (UserControl uc in a)
    {
        foreach (Control c in uc.Controls)
        {
            if (c.Name.StartsWith("SC")) { c.ForeColor = Color.FromArgb(rr, gg, bb); }
        }
    }

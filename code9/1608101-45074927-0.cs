    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        Point pAbs = panel1.AutoScrollPosition;
        pAbs.Offset(e.Location);
        label1.Text = "relative to control: " +  e.Location.ToString() +
                      "  absolute in scroll area " + pAbs.ToString();
    }

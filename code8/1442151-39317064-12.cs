    void hookUpControls(TableLayoutPanel tlp)
    {
        foreach (Control ctl in tlp.Controls)
        {
            ctl.MouseMove += (s, e) => { testTLP(tlp, ctl); };
        }
    }

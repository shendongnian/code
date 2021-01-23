    void spaceControls(List<Control> ctls, Control container)
    {
        int w = container.ClientSize.Width;
        int marge = (w - ctls.Sum(x => x.Width)) / (ctls.Count * 2 );
        Padding oldM = ctls[0].Margin;
        Padding newM = new Padding(marge, oldM.Top, marge, oldM.Bottom);
        foreach (Control c in ctls) c.Margin = newM;
    }

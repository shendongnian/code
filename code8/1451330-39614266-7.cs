    void centerControls(List<Control> ctls, Control container)
    {
        int w = container.ClientSize.Width;
        int marge = (w - ctls.Sum(x => x.Width)) / 2;
        Padding oldM = ctls[0].Margin;
        ctls.First().Margin = new Padding(marge, oldM.Top, oldM.Right, oldM.Bottom);
        ctls.Last().Margin = new Padding(oldM.Left, oldM.Top, oldM.Right, marge);
    }

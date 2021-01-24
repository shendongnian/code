    // Adds a control to an existing tab page # or creates a new page if it doesn't exist 
    // The value returned will be the actual page number which may not match
    // the requested page number.
    public int AddControl(int tabPage, Control control)
    {
        TabPage tbpg;
        if (tabControl1.TabPages.Count <= tabPage)
            tbpg = tabControl1.TabPages[tabPage];
        else
        {
            tbpg = new TabPage();
            tabControl1.TabPages.Add(tbpg);
        }
        tbpg.controls.Add(control);
        return tabcontrol1.TabPages.IndexOf(tbpg);
    }

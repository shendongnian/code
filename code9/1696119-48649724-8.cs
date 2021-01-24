    private Point CachedLocation;
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0112) // WM_SYSCOMMAND
        {
            if (m.WParam == new IntPtr(0xF020)) // SC_MINIMIZE
            {
                // save the form location beofore it is minimized
                   CachedLocation= this.Location;
            }
            m.Result = new IntPtr(0);
        }
    
        base.WndProc(ref m);
    }

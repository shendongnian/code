    const int WM_SYSCOMMAND = 0x0112;
    const int SC_MAXIMIZE = 0xF030;
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_SYSCOMMAND) 
        {
            if (m.WParam == (IntPtr)SC_MAXIMIZE) 
            {
                //the window has been maximized
                this.OnResizeEnd(EventArgs.Empty);
            }
        }
    }

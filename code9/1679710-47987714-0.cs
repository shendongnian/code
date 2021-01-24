    protected override void WndProc(ref Message m)
    {
        switch ((Win32.Msgs)m.Msg)
        {
            case Win32.Msgs.WM_DRAWCLIPBOARD:
            // Handle clipboard changed
            break;
            // ... 
       }
       // we call this so we to pass the message along
       base.WndProc(ref m);
    }

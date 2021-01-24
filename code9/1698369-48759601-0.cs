    const int WM_SETCURSOR = 0x0020;
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_SETCURSOR)
        {
            base.DefWndProc(ref m);
        }
        else
            base.WndProc(ref m);
    }

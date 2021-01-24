    protected override void WndProc(ref Message m)
    {
        if (m.Msg == Program.MutexMessage)
        {
            if (NativeMethods.IsIconic(Handle))
                NativeMethods.ShowWindow(Handle, 0x00000009);
            NativeMethods.SetForegroundWindow(Handle);
        }
        base.WndProc(ref m);
    }

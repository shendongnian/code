    bool ignoreMessages = false;
    public void DockWindow()
    {
        ignoreMessages = true;
        ShowWindow(handle, SW_MAXIMIZE);
        ignoreMessages = false;
        MoveWindow(handle, 0, 0, Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height, true);
    }
    protected override void WndProc(ref Message message)
    {
        if (ignoreMessages &&
            message.Msg != WM_NCPAINT)
            return;
        base.WndProc(ref message);
    }

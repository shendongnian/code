    protected override void WndProc(ref Message m) 
    {
        if (m.Msg == 0x0312 && m.WParam.ToInt32() == HOTKEY) 
        {
            //do something when pressed
        }
        base.WndProc(ref m);
    }

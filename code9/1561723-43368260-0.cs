    protected override void WndProc(ref Message m)
    {
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MAXIMIZE   = 0xF030;
        const int SC_RESTORE    = 0xF120;
    
        if (m.Msg == WM_SYSCOMMAND)
        {
            switch((int)m.WParam)
            {
                case SC_RESTORE:
                    // your window was restored ( double clicked on the command bar )
                    // set it's window state back to maximize or do whatever
                    break;
    
                 case SC_MAXIMIZE:
                     // your window was maximized .. no actions needed, just for debugging purpose
                      break;
            }
        }
        base.WndProc(ref m);
    }

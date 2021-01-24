    protected override void WndProc(ref Message m)
    {
         if (m.Msg == WM_CLIPBOARDUPDATE)
         {
            // handle message
         }
         base.WndProc(ref m);
    }

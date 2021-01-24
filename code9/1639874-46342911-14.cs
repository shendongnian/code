    private void ColoredTabControl_ControlAdded( object sender, ControlEventArgs e )
    {
        FindUpDown();
    }
    private void ColoredTabControl_SelectedIndexChanged( object sender, EventArgs e )
    {
        this.Invalidate();
    }
    protected override void Dispose( bool disposing )
    {
        if(scUpDown != null)
        {
            scUpDown.SubClassedWndProc -= scUpDown_SubClassedWndProc;
        }
        base.Dispose( disposing );
    }
    bool bUpDown = false;
    SubClass scUpDown = null;
    private void FindUpDown()
    {
        bool bFound = false;
        // find the UpDown control
        IntPtr pWnd =
            Win32.GetWindow( this.Handle, Win32.GW_CHILD );
        while( pWnd != IntPtr.Zero )
        {
            // Get the window class name
            char[] fullName = new char[ 33 ];
            int length = Win32.GetClassName( pWnd, fullName, 32 );
            string className = new string( fullName, 0, length );
            if( className == Win32.MSCTLS_UPDOWN32 )
            {
                bFound = true;
                if( !bUpDown )
                {
                    // Subclass it
                    this.scUpDown = new SubClass( pWnd, true );
                    this.scUpDown.SubClassedWndProc +=
                        new SubClass.SubClassWndProcEventHandler(
                                             scUpDown_SubClassedWndProc );
                    bUpDown = true;
                }
                break;
            }
            pWnd = Win32.GetWindow( pWnd, Win32.GW_HWNDNEXT );
        }
        if( ( !bFound ) && ( bUpDown ) )
            bUpDown = false;
    }
    private int scUpDown_SubClassedWndProc( ref Message m )
    {
        switch(m.Msg)
        {
            case Win32.WM_LCLICK:
                //Invalidate to repaint
                this.Invalidate();
                return 0;
        }
        return 0;
    }

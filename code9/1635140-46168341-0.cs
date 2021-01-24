    [DllImport ("coredll")]
    private static extern long ShowScrollBar (long hwnd , long wBar, long bShow);
    long SB_HORZ = 0;
    long SB_VERT = 1;
    long SB_BOTH = 3;
    
    private void HideHorizontalScrollBar ()
    {
        ShowScrollBar(listView1.Handle.ToInt64(), SB_HORZ, 0);
    }
    private void HideScrollBars ()
    {
        ShowScrollBar(listView1.Handle.ToInt64(), SB_BOTH, 0);
    }

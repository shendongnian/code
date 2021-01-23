	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
	private enum ScrollBarDirection
	{
		SB_HORZ = 0,
		SB_VERT = 1,
		SB_CTL = 2,
		SB_BOTH = 3
	}
	protected override void WndProc(ref System.Windows.Forms.Message m)
	{
		ShowScrollBar(panel1.Handle, (int)ScrollBarDirection.SB_VERT, false);
		base.WndProc(ref m);
	}
	

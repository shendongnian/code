    private void Form_Load(object sender, EventArgs e)
    {
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.WindowState = FormWindowState.Maximized;
        this.MaximizeBox = false;
        this.MinimumSize = Screen.GetWorkingArea(this.Location).Size;
    }
    private const int WM_NCLBUTTONDBLCLK = 0x00A3; 
    //double click on a title bar
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_NCLBUTTONDBLCLK)
        {
            m.Result = IntPtr.Zero;
            return;
        }
        base.WndProc(ref m);
    }

    public class RButton : Button
    {
        public delegate void MouseDoubleRightClick(object sender, MouseEventArgs e);
        public event MouseDoubleRightClick DoubleRightClick;
        protected override void WndProc(ref Message m)
        {
            const Int32 WM_RBUTTONDBLCLK = 0x0206;
            if (m.Msg == WM_RBUTTONDBLCLK)
                DoubleRightClick(this, null);
            base.WndProc(ref m);
        }
    }

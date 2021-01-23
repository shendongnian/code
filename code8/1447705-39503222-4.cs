    using Microsoft.VisualBasic.PowerPacks;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class DataRepeaterItemHelper : NativeWindow
    {
        private DataRepeaterItem item;
        private const int WM_NCPAINT = 0x85;
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        public DataRepeaterItemHelper(DataRepeaterItem repeaterItem)
        {
            item = repeaterItem;
            this.AssignHandle(item.Handle);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT)
            {
                var hdc = GetWindowDC(m.HWnd);
                using (var g = Graphics.FromHdcInternal(hdc))
                using (var p = new Pen(item.BackColor, 1))
                    g.DrawLine(p, 0, item.Height - 1, item.Width - 1, item.Height - 1);
                ReleaseDC(m.HWnd, hdc);
            }
        }
    }

    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class MyMaskedTextBox : MaskedTextBox
    {
        public const int WM_NCPAINT = 0x85;
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT)
            {
                var hdc = GetWindowDC(this.Handle);
                using (var g = Graphics.FromHdcInternal(hdc))
                {
                    g.DrawRectangle(Pens.Blue, new Rectangle(0, 0, Width - 1, Height - 1));
                }
                ReleaseDC(this.Handle, hdc);
                m.Result = IntPtr.Zero;
            }
        }
    }

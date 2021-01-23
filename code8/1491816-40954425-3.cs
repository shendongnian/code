    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
<!---->
    public class MyProgressBar : Control
    {
        public MyProgressBar() 
        {
            DoubleBuffered = true;
            Minimum = 0; Maximum = 100; Value = 50;
        }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Value { get; set; }
        protected override void OnPaint(PaintEventArgs e) 
        {
            base.OnPaint(e);
            Draw(e.Graphics);
        }
        private void Draw(Graphics g) 
        {
            var r = this.ClientRectangle;
            using (var b = new SolidBrush(this.BackColor))
                g.FillRectangle(b, r);
            TextRenderer.DrawText(g, this.Value.ToString(), this.Font, r, this.ForeColor);
            var hdc = g.GetHdc();
            var c = this.ForeColor;
            var hbrush = CreateSolidBrush(((c.R | (c.G << 8)) | (c.B << 16)));
            var phbrush = SelectObject(hdc, hbrush);
            PatBlt(hdc, r.Left, r.Y, (Value * r.Width / Maximum), r.Height, PATINVERT);
            SelectObject(hdc, phbrush);
            DeleteObject(hbrush);
            g.ReleaseHdc(hdc);
        }
        public const int PATINVERT = 0x005A0049;
        [DllImport("gdi32.dll")]
        public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft,
            int nWidth, int nHeight, int dwRop);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateSolidBrush(int crColor);
    }

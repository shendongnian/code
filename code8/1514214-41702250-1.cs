    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            static extern bool GetCursorPos(ref Point lpPoint);
    
            [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
            public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
    
    
            public Color GetColorAt(Point location)
            {
                using (Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
                {
                    using (Graphics gdest = Graphics.FromImage(screenPixel))
                    {
                        using (Graphics gsrc = Graphics.FromHwnd(pictureBox1.Handle))
                        {
                            IntPtr hSrcDC = gsrc.GetHdc();
                            IntPtr hDC = gdest.GetHdc();
                            int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                            gdest.ReleaseHdc();
                            gsrc.ReleaseHdc();
                        }
                    }
    
                    return screenPixel.GetPixel(0, 0);
                }
            }
    
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                panel1.BackColor = GetColorAt(e.Location);
            }
        }
    }

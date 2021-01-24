    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            // Opens an image file.
            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.image = Image.FromFile(dlg.FileName) as Bitmap;
                    this.pictureBox1.Image = image;
                    this.pictureBox1.Size = image.Size;
                    this.pictureBox1.Invalidate();
                }
            }
    
            Bitmap image;
    
            // finds top, left, right and bottom bounds of the content in TIFF file.
            // 
            private void findBoundsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                int contentSize = 70;
    
                this.left = 0;
                this.top = 0;
                this.right = this.pictureBox1.Width - 1;
                this.bottom = this.pictureBox1.Bottom - 1;
    
                int h = image.Height;
                int w = image.Width;
                this.progressBar1.Value = 0;
                this.progressBar1.Maximum = 4;
    
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
    
                        if (this.image.GetPixel(x, y).ToArgb() == Black)
                        {
                            int size = this.image.GetBlackRegionSize(x, y);
                            if (this.image.GetBlackRegionSize(x, y) > contentSize)
                            {
                                this.top = y;
                                goto label10;
                            }
                        }
    
                    }
                }
    
            label10:
                this.progressBar1.Increment(1);
                for (int y = h - 1; y >= 0; y--)
                {
                    for (int x = 0; x < w; x++)
                    {
    
                        if (this.image.GetPixel(x, y).ToArgb() == Black)
                        {
                            if (this.image.GetBlackRegionSize(x, y) > contentSize)
                            {
                                this.bottom = y;
                                goto label11;
                            }
                        }
                    }
                }
    
            label11:
                this.progressBar1.Increment(1);
                for (int x = 0; x < w; x++)
                {
                    for (int y = 0; y < h; y++)
                    {
    
                        if (this.image.GetPixel(x, y).ToArgb() == Black)
                        {
                            if (this.image.GetBlackRegionSize(x, y) > contentSize)
                            {
                                this.left = x;
                                goto label12;
                            }
                        }
                    }
                }
    
            label12:
                this.progressBar1.Increment(1);
                for (int x = w - 1; x >= 0; x--)
                {
                    for (int y = 0; y < h; y++)
                    {
    
                        if (this.image.GetPixel(x, y).ToArgb() == Black)
                        {
                            if (this.image.GetBlackRegionSize(x, y) > contentSize)
                            {
                                this.right = x;
                                goto label13;
                            }
                        }
                    }
                }
    
            label13:
                this.progressBar1.Increment(1);
    
                this.pictureBox1.Invalidate();
            }
    
            internal static readonly int Black = Color.Black.ToArgb();
            internal static readonly int White = Color.White.ToArgb();
    
            int top;
            int bottom;
            int left;
            int right;
    
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawRectangle(Pens.Red, this.left, this.top, this.right - this.left, this.bottom - this.top);
            }
        }
    
        static class BitmapHelper
        {
            internal static int GetBlackRegionSize(this Bitmap image, int x, int y)
            {
                int size = 0;
                GetRegionSize(image, new List<Point>(), x, y, 0, ref size);
                return size;
            }
    
            // this constant prevents StackOverFlow exception.
            // also it has effect on performance.
            // It must bigger than the value of contentSize in findBoundsToolStripMenuItem_Click(object sender, EventArgs e) method.
            const int MAXLEVEL = 100;
    
            static void GetRegionSize(this Bitmap image, List<Point> list, int x, int y, int level, ref int size)
            {
                if (x >= image.Width || x < 0 || y >= image.Height || y < 0 || list.Contains(x, y) || image.GetPixel(x, y).ToArgb() != Form1.Black || level > MAXLEVEL)
                {
                    return;
                }
    
                if (size < level)
                {
                    size = level;
                }
    
                list.Add(new Point(x, y));
    
                image.GetRegionSize(list, x, y - 1, level + 1, ref size);
                image.GetRegionSize(list, x, y + 1, level + 1, ref size);
                image.GetRegionSize(list, x - 1, y, level + 1, ref size);
                image.GetRegionSize(list, x + 1, y, level + 1, ref size);
            }
    
            static bool Contains(this List<Point> list, int x, int y)
            {
                foreach (Point point in list)
                {
                    if (point.X == x && point.Y == y)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    
    }

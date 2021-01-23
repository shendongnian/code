    ...
    using System.Windows.Forms;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Drawing2D;
    ..
    ..
    class Program
    {
        static void Main(string[] args)
        {
            float[] data = initData(10000);
            Size imgSize = new Size(1000, 400);
            Bitmap bmp = drawGraph(data, imgSize , Color.Green, Color.Black);
            bmp.Save("D:\\wave.png", ImageFormat.Png);
        }
        static float[] initData(int count)
        {
            float[] data = new float[count];
            for (int i = 0; i < count; i++ )
            {
                data[i] = (float) ((Math.Sin(i / 12f) * 880 + Math.Sin(i / 15f) * 440
                                  + Math.Sin(i / 66) * 110) / Math.Sqrt((i+1f)/10f));
            }
            return data;
        }
        static Bitmap drawGraph(float[] data, Size size, Color ForeColor, Color BackColor)
        {
            Bitmap bmp = new System.Drawing.Bitmap(size.Width, size.Height, 
                                    PixelFormat.Format32bppArgb);
            Padding borders = new Padding(20, 20, 10, 50);
            Rectangle plotArea = new Rectangle(borders.Left, borders.Top,
                           size.Width - borders.Left - borders.Right, 
                           size.Height - borders.Top - borders.Bottom);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen pen = new Pen(Color.FromArgb(224, ForeColor),1.75f))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Silver);
                using (SolidBrush brush = new SolidBrush(BackColor))
                    g.FillRectangle(brush, plotArea);
                g.DrawRectangle(Pens.LightGoldenrodYellow, plotArea);
                g.TranslateTransform(plotArea.Left, plotArea.Top);
                g.DrawLine(Pens.White, 0, plotArea.Height / 2,
                       plotArea.Width,  plotArea.Height / 2);
                float dataHeight = Math.Max( data.Max(), - data.Min()) * 2;
                float yScale = 1f * plotArea.Height / dataHeight;
                float xScale = 1f * plotArea.Width / data.Length;
                g.ScaleTransform(xScale, yScale);
                g.TranslateTransform(0, dataHeight / 2);
                var points = data.ToList().Select((y, x) => new { x, y })
                                 .Select(p => new PointF(p.x, p.y)).ToList();
                g.DrawLines(pen, points.ToArray());
                g.ResetTransform();
                g.DrawString(data.Length + " points plotted.", 
                    new Font("Consolas", 14f), Brushes.Black, 
                    plotArea.Left, plotArea.Bottom + 2f);
            }
            return bmp;
        }
    }

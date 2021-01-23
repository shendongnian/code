        private Bitmap GetBitmapWithEllipses(float radius)
        {
            Bitmap bmp = new Bitmap(512, 512);
            Random r = new Random();
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                List<RectangleF> rects = new List<RectangleF>();
                rects.Add(new RectangleF(0, 0, 0, 0));
                for (int x = 0; x < numberOfPoints; x++)
                {
                    for (int y = 0; y < numberOfPoints; y++)
                    {
                        Color c = Color.FromArgb(
                            r.Next(0, 256),
                            r.Next(0, 256),
                            r.Next(0, 256));
                        PointF p = new PointF(r.Next(Width), r.Next(Height));
                        RectangleF rect = new RectangleF(p, new SizeF(radius * 2, radius * 2));
                        if (!rects.Any(tmp => tmp.IntersectsWith(rect)))
                        {
                            rects.Add(rect);
                            g.FillEllipse(new SolidBrush(c), rect);
                        }
                        else
                        {
                            y--;
                        }
                    }
                }
            }
            return bmp;
        }

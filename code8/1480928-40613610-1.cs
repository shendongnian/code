    static void Main(string[] args)
    {
        int w = 1234;
        int h = 1234;
        Random rnd = new Random(0);
        for (int t = 0; t < 33; t++)
        {
            List<Point> l1 = new List<Point>();
            List<Point> l2 = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                l1.Add(new Point(rnd.Next(1234), rnd.Next(567)));
                l2.Add(new Point(rnd.Next(567), rnd.Next(1234)));
            }
            using (Matrix m = new Matrix())
            using (Bitmap bmp = new Bitmap(w, h))
            using (Graphics g = Graphics.FromImage(bmp))
            using (GraphicsPath gp1 = new GraphicsPath())
            using (GraphicsPath gp2 = new GraphicsPath())
            {
                gp1.AddLines(l1.ToArray());
                gp2.AddLines(l2.ToArray());
                m.Translate(50, 0);
                bool intersects = intersect(gp1, gp2, g);
                g.Clear(Color.White);
                g.DrawPath(Pens.Blue, gp1);
                g.DrawPath(intersects ? Pens.Red : Pens.Green, gp2);
                while (intersects)
                {
                    gp2.Transform(m);
                    intersects = intersect(gp1, gp2, g);
                    g.DrawPath(intersects ? Pens.Red : Pens.Green, gp2);
                    intersects = intersect(gp1, gp2, g);
                }
                bmp.Save(@"D:\scrape\x\__xTest_" + t.ToString("000") + ".png", 
                         ImageFormat.Png);
            }
        }
    }

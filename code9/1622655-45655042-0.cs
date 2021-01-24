            Bitmap bmp = new Bitmap("test.bmp");
            Bitmap bmp2;
            Graphics g = Graphics.FromImage(bmp2=new Bitmap(bmp.Width * 2, bmp.Height * 2));
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(bmp, 0, 0, bmp.Width * 2, bmp.Height * 2);
            g.Dispose();

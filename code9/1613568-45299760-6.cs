    static void Fill4(Bitmap bmp, Point pt, Color c0, Color c1)
    {
        Color cx = bmp.GetPixel(pt.X, pt.Y);
        if (cx.GetBrightness() < 0.01f) return;  // optional, to prevent filling a black grid
        Rectangle bmpRect = new Rectangle(Point.Empty, bmp.Size);
        Stack<Point> stack = new Stack<Point>();
        int x0 = pt.X;
        int y0 = pt.Y;
        stack.Push(new Point(x0, y0) );
        while (stack.Any() )
        {
            Point p = stack.Pop();
            if (!bmpRect.Contains(p)) continue;
            cx = bmp.GetPixel(p.X, p.Y);
            if (cx == c0)
            {
                bmp.SetPixel(p.X, p.Y, c1);
                stack.Push(new Point(p.X, p.Y + 1));
                stack.Push(new Point(p.X, p.Y - 1));
                stack.Push(new Point(p.X + 1, p.Y));
                stack.Push(new Point(p.X - 1, p.Y));
            }
        }
    }

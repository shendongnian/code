    void DrawDottedLine(Graphics g, Pen pen_, Point pa_, Point pb_)
    {
        Point pa = pa_;
        Point pb = pb_;
        bool vertical = pa.X == pb.X;
        bool horizontal = pa.Y == pb.Y;
        float pw = pen_.Width;
        float pw2 = pen_.Width / 2;
        Pen pen = pen_;
        int sigX = Math.Sign(pb.X - pa.X);
        int sigY = Math.Sign(pb.Y - pa.Y);
        if (horizontal) pa.X -= (int)pw2 * sigX;
        if (horizontal) pb.X += (int)pw2 * sigX;
        if (vertical) pa.Y -= (int)pw2 * sigY;
        if (vertical) pb.Y += (int)pw2 * sigY;
        float lw = (float)(Math.Abs(pb.X - pa.X));
        float lh = (float)(Math.Abs(pb.Y - pa.Y));
        int gch = (int)(lw / 4);
        int gcv = (int)(lh / 4);
        int dch = gch + 1;
        int dcv = gcv + 1;
        float gs = 1f;
        if (vertical)  gs =  (lh - dcv * pw) / gcv;
        if (horizontal)  gs =  (lw - dch * pw) / gch ;
        gs = pw / gs;
        pen.DashPattern = new float[] { 1, gs };
        g.DrawLine(pen, pa, pb);
    }

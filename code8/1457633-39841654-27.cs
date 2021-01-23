    void DrawDottedLine(Graphics g, Pen pen_, Point pa_, Point pb, byte skipDots)
    {
        float pw = pen_.Width;
        float pw2 = pen_.Width / 2f;
        Pen pen = pen_;
        // find out directions:
        int sigX = Math.Sign(pb_.X - pa_.X);
        int sigY = Math.Sign(pb_.Y - pa_.Y);
        // move the end points out a bit:
        PointF pa = new PointF(pa_.X - pw2 * sigX, pa_.Y - pw2 * sigY);
        PointF pb = new PointF(pb_.X + pw2 * sigX, pb_.Y + pw2 * sigY);
        // find line new length:
        float lw = (float)(Math.Abs(pb.X - pa.X));
        float lh = (float)(Math.Abs(pb.Y - pa.Y));
        float ll = (float)(Math.Sqrt(lw * lw + lh * lh));
        // dot length:
        float dl = ll / pw;
        // dot+gap count: round to nearest odd int:
        int dc = (int)(2 * Math.Round((dl + 1) / 2) - 1);
        //  gap count:
        int gc = dc / 2 ;
        // dot count:
        dc = gc + 1;
        // gap scaling
        float gs = (ll - dc * pw) / (pw * gc);
        // our custom dashpattern 
        pen.DashPattern = new float[] { 1, gs };
        // maybe skip 1st and/or last dots:
        if (skipDots % 2 == 1) pa = new PointF(pa_.X + pw * sigX, pa_.Y + pw * sigY);
        if (skipDots > 1) pb = new PointF(pb_.X - pw * sigX, pb_.Y - pw * sigY);
        g.DrawLine(pen, pa, pb);
        // reset the pen
        pen.DashPattern = new float[] { 1, 1 };
    }

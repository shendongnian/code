    System.Diagnostics.Stopwatch s1 = System.Diagnostics.Stopwatch.StartNew();
    using (Graphics dr = Graphics.FromImage(img))
    {
        dr.DrawLines(bluePen, points);
    }
    s1.Stop();

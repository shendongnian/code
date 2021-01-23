    //if (!rects.Any(tmp => tmp.IntersectsWith(rect)))
    //{
        rects.Add(rect);
        g.FillEllipse(new SolidBrush(c), rect);
    //}
    //else
    //{
    //    y--;
    //}

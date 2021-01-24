    /// <summary>
    /// Create a perpendicular offset point at a position located along a line segment.
    /// </summary>
    /// <param name="a">Input. PointD(x,y) of p1.</param>
    /// <param name="b">Input. PointD(x,y) of p2.</param>
    /// <param name="position">Distance between p1(0.0) and p2 (1.0) in a percentage.</param>
    /// <param name="offset">Distance from position at 90degrees to p1 and p2- non-percetange based.</param>
    /// <param name="c">Output of the calculated point along p1 and p2. might not be necessary for the ultimate output.</param>
    /// <param name="d">Output of the calculated offset point.</param>
    private void PerpOffset(PointD a, PointD b, double position, double offset, out PointD c, out PointD d)
    {
        //p3 is located at the x or y delta * position + x or y delta.
        PointD p3 = new PointD(((b.X - a.X) * position) + a.X, ((b.Y - a.Y) * position) + a.Y);
        //returns an angle in radians between p1 and p2 + 1.5708 (90degress).
        double angleRadians = Math.Atan2(a.Y - b.Y, a.X - b.X) + 1.5708;
        //locates p4 at the given angle and distance from p3.
        PointD p4 = new PointD(p3.X + Math.Cos(angleRadians) * offset, p3.Y + Math.Sin(angleRadians) * offset);
        //send out the calculated points
        c = p3;
        d = p4;
    }

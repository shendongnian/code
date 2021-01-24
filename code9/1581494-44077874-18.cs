    public static List<ISegment> GenerateSegmentList()
    {
        // Generate the points in the diagram
        var A = new Point3D(0, 0, 0);
        var B = new Point3D(0, 0, 1);
        var C = new Point3D(0, 0, 2);
        var D = new Point3D(0, 0, 3);
        var E = new Point3D(0, 0, 4);
        var F = new Point3D(0, 0, 5);
        var G = new Point3D(0, 0, 6);
        var H = new Point3D(0, 0, 7);
        var I = new Point3D(0, 0, 8);
        var J = new Point3D(0, 0, 9);
        var K = new Point3D(0, 1, 0);
        var L = new Point3D(0, 1, 1);
        var M = new Point3D(0, 1, 2);
        var N = new Point3D(0, 1, 3);
        // Generate the segments in the diagram
        return new List<ISegment>
        {
            new Line("s1", A, B),
            new Line("s2", B, C),
            new Line("s3", C, D),
            new Line("s4", D, E),
            new Line("s5", F, G),
            new Line("s6", G, H),
            new Arc("s7", I),
            new Line("s8", J, K),
            new Line("s9", K, L),
            new Line("s10", L, J),
            new Line("s11", M, N),
            new Arc("s12", N, M)
        };
    }
    public static bool IsSingleSegmentChain(ISegment segment)
    {
        return segment != null && segment.A == segment.B;
    }
    public static bool ContainsPoint(ISegment segment, Point3D pointToMatch)
    {
        return segment != null && (segment.A == pointToMatch || segment.B == pointToMatch);
    }
    public static Point3D GetNonMatchingPoint(ISegment segment, Point3D pointToMatch)
    {
        return segment == null
            ? default(Point3D)
            : (segment.A == pointToMatch)
                ? segment.B
                : segment.A;
    }

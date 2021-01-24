    public static class Extensions
    {
            // Adds an arc (fillet) at each vertex, if able.
            public static void FilletAll(this Polyline pline, double radius)
        {
            int i = pline.Closed ? 0 : 1;
            for (int j = 0; j < pline.NumberOfVertices - i; j += 1 + pline.FilletAt(j, radius))
            { }
        }
    
        // Adds an arc (fillet) at the specified vertex. Returns 1 if the operation succeeded, 0 if it failed.
        public static int FilletAt(this Polyline pline, int index, double radius)
        {
            int prev = index == 0 && pline.Closed ? pline.NumberOfVertices - 1 : index - 1;
    
            if (pline.GetSegmentType(prev) != _AcDb.SegmentType.Line ||
              pline.GetSegmentType(index) != _AcDb.SegmentType.Line)
                return 0;
    
            LineSegment2d seg1 = pline.GetLineSegment2dAt(prev);
            LineSegment2d seg2 = pline.GetLineSegment2dAt(index);
    
            Vector2d vec1 = seg1.StartPoint - seg1.EndPoint;
            Vector2d vec2 = seg2.EndPoint - seg2.StartPoint;
    
            double angle = (Math.PI - vec1.GetAngleTo(vec2)) / 2.0;
            double dist = radius * Math.Tan(angle);
            if (dist > seg1.Length || dist > seg2.Length)
                return 0;
    
            Point2d pt1 = seg1.EndPoint + vec1.GetNormal() * dist;
            Point2d pt2 = seg2.StartPoint + vec2.GetNormal() * dist;
    
            double bulge = Math.Tan(angle / 2.0);
            if (Clockwise(seg1.StartPoint, seg1.EndPoint, seg2.EndPoint))
                bulge = -bulge;
    
            pline.AddVertexAt(index, pt1, bulge, 0.0, 0.0);
            pline.SetPointAt(index + 1, pt2);
    
            return 1;
        }
    
            // Evaluates if the points are clockwise.
            private static bool Clockwise(Point2d p1, Point2d p2, Point2d p3)
        {
            return ((p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X)) < 1e-8;
        }
    }

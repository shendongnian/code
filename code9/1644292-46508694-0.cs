    static class Program
    {
        static void Main(string[] args)
        {
            // Start Program Here
            // Define three points, A, B, & C
            Point2 A = Point2.FromCoordinates(3, -1);
            Point2 B = Point2.FromCoordinates(0.8, 2);
            Point2 C = Point2.FromCoordinates(-1, 0.2);
            // Get a line between A & B
            Line2 AB = Line2.FromTwoPoints(A, B);
            // Get point on line closest to C
            Point2 D = Geometry.Closest(AB, C);
            // Check distance between C & AB equals distance between C & D
            double d_CAB = Geometry.Distance(C, AB);
            double d_CD = Geometry.Distance(C, D);
            double diff = d_CAB-d_CD;
            // Check that D is coincident to AB
            bool check_DAB = Geometry.AreNear(D, AB);
            // Get a line between C & D
            Line2 CD = Line2.FromTwoPoints(C, D);
            // Get a line @ C parallel to AB
            Line2 L = Line2.ThroughPointParallelToLine(C, AB);
            double d_CAB2 = Geometry.Distance(L, AB);
            double diff2 = d_CAB2-d_CAB;
            // Get a line @ C perpendicular to AB
            Line2 M = Line2.ThroughPointNormalToLine(C, AB);
            // Check intersection of M and AB that is actually point D
            bool check_DM = Geometry.AreNear(D, Geometry.Meet(M, AB));
        }
    }

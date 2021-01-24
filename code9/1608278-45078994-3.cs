    static byte HoleTooClose(HoleInfo x, HoleInfo y, float minDistance)
    {
        float holeSize = (x.Diameter + y.Diameter) / 2;
        float deltaX = y.X - x.X;
        float deltaY = y.Y - x.Y;
        float distanceSquared = deltaX * deltaX + deltaY * deltaY - holeSize * holeSize;
        if (distanceSquared <= 0)
        {
            return 0;
        }
        float minDistanceSquared = minDistance * minDistance;
        if (distanceSquared <= minDistanceSquared)
        {
            return 1;
        }
        return 2;
    }
    internal struct HoleInfo
    {
        public float Diameter { get; internal set; }
        public float X { get; internal set; }
        public float Y { get; internal set; }
        public HoleInfo (float x, float y, float diameter)
        {
            X = x;
            Y = y;
            Diameter = diameter;
        }
    }
    
    static bool DistanceTooClose(System.Windows.Point x, System.Windows.Point y, Double minDistance)
    {
        double deltaX = Math.Abs(y.X - x.X);
        double deltaY = Math.Abs(y.Y - x.Y);
        double distanceSquared = deltaX * deltaX + deltaY * deltaY;
        //double distance = Math.Sqrt(distanceSquared);
        Double minDistanceSquared = minDistance * minDistance;
        return (distanceSquared <= minDistanceSquared);
    }

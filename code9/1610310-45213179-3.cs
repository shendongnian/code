    [TypeConverter(typeof(ExpandableObjectConverter))]
    public struct Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

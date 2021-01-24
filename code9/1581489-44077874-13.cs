    public interface ISegment
    {
        string Name { get; }
        Point3D A { get; }
        Point3D B { get; }
    }
    public class Line : ISegment
    {
        public string Name { get; }
        public Point3D A { get; }
        public Point3D B { get; }
        public Line(string name, Point3D a, Point3D b)
        {
            Name = name;
            A = a;
            B = b;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Arc : ISegment
    {
        public string Name { get; }
        public Point3D A { get; }
        public Point3D B { get; }
        public Arc(string name, Point3D singlePoint) : this(name, singlePoint, singlePoint)
        {
        }
        public Arc(string name, Point3D a, Point3D b)
        {
            Name = name;
            A = a;
            B = b;
        }
        public override string ToString()
        {
            return Name;
        }
    }

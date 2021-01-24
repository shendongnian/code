    public abstract class Segment : ISegment
    {
        public string Name { get; }
        public Point3D A { get; }
        public Point3D B { get; }
        protected Segment(string name, Point3D a, Point3D b)
        {
            Name = name;
            A = a;
            B = b;
        }
        public bool ContainsPoint(Point3D point)
        {
            return A == point || B == point;
        }
        public Point3D GetNonMatchingPoint(Point3D point)
        {
            return A == point ? B : A;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Line : Segment
    {
        public Line(string name, Point3D a, Point3D b) : base(name, a, b)
        { }
    }
    public class Arc : Segment
    {
        public Arc(string name, Point3D singlePoint) : base(name, singlePoint, singlePoint)
        { }
        public Arc(string name, Point3D a, Point3D b) : base(name, a, b)
        { }
    }

    public class MyPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class PointComparer : IEqualityComparer<MyPoint>
    {
        public bool Equals(MyPoint x, MyPoint y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            return (x.X == y.X && x.Y == y.Y) ||
                   (x.X == y.Y && x.Y == y.X);
        }
        public int GetHashCode(MyPoint obj)
        {
            return obj.X.GetHashCode() ^ obj.Y.GetHashCode();
        }
    }
    class Program
    {
        static void Main()
        {
            List<MyPoint> data = GetDataFromSomewhere();
            var singularData = data.Distinct(new PointComparer()).ToList();
        }
    }

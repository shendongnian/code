    public class Points : IEnumerable<Point3D>
    {
        private readonly List<Point3D> _points;
    
        public Points()
        {
            _points = new List<Point3D>();
        }
    
        public void Add(double x, double y, double z)
        {
            _points.Add(new Point3D(x, y, z));
        }
    
        public IEnumerator<Point3D> GetEnumerator()
        {
            return _points.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class GeoPoint
    {
        [Key]
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        [NotMapped]
        public PointF GetPointF { get { return new PointF(X, Y); } }
        public GeoPoint()
        {
            X = 0; Y = 0;
        }
        public GeoPoint(float x, float y)
        {
            X = x; Y = y;
        }
        public GeoPoint(PointF point)
        {
            X = point.X;
            Y = point.Y;
        }
    
    }

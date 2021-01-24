    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Perspective
    {
        public float X_shift { get; set; } = 0.0f;
        public float Y_shift { get; set; } = 0.0f;
        public float X_x { get; set; } = 1.0f;
        public float X_y { get; set; } = 0.0f;
        public float X_z { get; set; } = 0.0f;
        public float Y_x { get; set; } = 0.0f;
        public float Y_y { get; set; } = 1.0f;
        public float Y_z { get; set; } = 0.0f;
        public PointF Project(Point3D p)
        {
            return new PointF(X_shift + X_x * p.X + X_y * p.Y + X_z * p.Z, Y_shift + Y_x * p.X + Y_y * p.Y + Y_z * p.Z);
        }
    }

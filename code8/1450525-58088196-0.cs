    public struct PointFloat
    {
        public float X;
        public float Y;
        public float Z;
    }
    public class Point
    {
        private PointFloat dbls;
        public float X
        {
            get { return dbls.X; }
            set { dbls.X = value; }
        }
        public float Y
        {
            get { return dbls.Y; }
            set { dbls.Y = value; }
        }
        public float Z
        {
            get { return dbls.Z; }
            set { dbls.Z = value; }
        }
    }

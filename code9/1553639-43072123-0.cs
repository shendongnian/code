    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Vector(float _x, float _y, float _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }
        public static Vector operator +(Vector _a, Vector _b)
        {
            return new Vector(_a.X + _b.X, _a.Y + _b.Y, _a.Z + _b.Z);
        }
    }

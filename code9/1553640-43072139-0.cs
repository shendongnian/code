    public struct Vector
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
    
        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X , a.Y + b.Y, a.Z + b.Z);
        }
    }

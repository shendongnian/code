    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string Property1 { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }
        protected bool Equals(Point other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }
    }        

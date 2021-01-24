    class Point : ICloneable
    {
        public int TouchGround;
        public object Clone()
        {
            return new Point
            {
                TouchGround = this.TouchGround
            }
        }
    }

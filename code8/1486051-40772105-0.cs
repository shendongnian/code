    class Polygon
    {
        public int NumSides;
    
        public Polygon(int numsides)
        {
            this.NumSides = numsides;
        }
    }
    
    class Square : Polygon
    {
        public readonly int SideLength;
        public Square(int SideLength) : base(4)
        {
            this.SideLength = SideLength;
        }
    }

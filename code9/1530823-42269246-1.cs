    class Square : Polygon {
    
        public int SideLength; 
    
        public Square (int sideLength, int numSides) : base(numSides) {
            SideLength = sidelength; 
            // NumSides will be handled by base class ctor
        }
        // ctor overload with fixed number of sides for squares
        public Square (int sideLength) : this(sideLength, 4) {
        }
    }

    class Polygon
    {
        public int Numberofsides { get; set; }
        public Polygon()
        {
    	    Numberofsides = 0;
        }
        public Polygon(int numberofsides)
        {
            Numberofsides = numberofsides;
        }
    }
    class Square : Polygon
    {
        public float Size { get; set; }
        public Square (float size)
        {
            Size = size;
            Numberofsides = 4;
        }
    }

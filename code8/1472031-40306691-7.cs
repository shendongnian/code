    public class Test
    {
        public double Index { set; get; }
        public double A { set; get; }
        public double B { set; get; }
        public double C 
        { 
           get
           {
                return A + B;
           } 
        }
    }

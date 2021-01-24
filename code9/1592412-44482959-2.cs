    public class Square : Rectangle
    {
        private double side1;
    
        public Square(string name, double side1) : base(name, side1, side1)
        {
            this.side1 = side1;
        }
    }

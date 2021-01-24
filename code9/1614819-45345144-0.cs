    public class Circle:Shape
    {
        public Circle():this(Color.Black, new Point(0,0), 1)
        {
        }
    
        public Circle(Color Colour, Point Position, double Radius):base(Colour, 
    Position) 
        {
            this.Radius = Radius;
        }
    }

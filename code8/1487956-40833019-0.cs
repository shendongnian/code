    abstract class Shape
    {
        public abstract double Area {get;}
    }
    class Square: Shape
    {
        public double Side {get;}
        public override double Area => Side * Side;
        public Square (double side)
        {
           this.Side = side;
        }
    }
    class Rectangle:Shape
    {
        public double Width {get;}
        public double Length {get;}
        public override double Area => Width * Length;
        public Rectangle (double width, double length)
        {   
           this.Width = width;
           this.Length = length;
        }
    }

    public abstract class Shape
    {
        public abstract double GetArea();
    }
    public class Circle : Shape
    {
        public int Radius { get; }
        public Circle(int radius)
        {
            Radius = radius;
        }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
    public class Square : Shape 
    {
        public int SideLength { get; }
        public Square(int sideLength)
        {
            SideLength = sideLength;
        }
        public override double GetArea()
        {
            return SideLength * SideLength;
        }
    }

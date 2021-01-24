    public class Rectangle
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }
        public double Area { get { return Width * Height; } }
    }
    
    public class Square : Rectangle
    {
        public override double Width { get { return Height; } set { Height = value; } }
    }

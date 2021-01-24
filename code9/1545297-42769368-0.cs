    public class Rectangle
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }
        public double Area { get { return Width * Height; } }
    }
    
    public class Square : Rectangle
    {
        public double Side { get; set; }
    
        public override double Height
        {
            get { return Side; }
            set { Side = value; }
        }
    
        public override double Width
        {
            get { return Side; }
            set { Side = value; }
        }
    }

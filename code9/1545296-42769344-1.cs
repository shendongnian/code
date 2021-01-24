    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
    public class Square : Rectangle
    {
        public override int Width
        {
            get { return Side; }
            set { Side = value; }
        }
        public override int Height
        {
            get { return Side; }
            set { Side = value; }
        }
        public int Side { get; set; }
        public Square(int side)
            : base(side, side)
        {
            Side = side;
        }
    }

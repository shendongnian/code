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
        private int _width;
        private int _height;
        public override int Width
        {
            get { return _width; }
            set { _width = _height = value; }
        }
        public override int Height
        {
            get { return _height; }
            set { _width = _height = value; }
        }
        public int Side
        {
            get { return _width; }
            set { _width = _height = value; }
        }
        public Square(int side)
            : base(side, side)
        {
            _width = _height = side;
        }
    }

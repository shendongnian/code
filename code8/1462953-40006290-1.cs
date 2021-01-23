         public class Window
    {
        private int _size { get; set; }
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (value >= MyBox.Size)
                    _size = value;
            }
        }
        public Box MyBox { get; set; }
        public Window(int myWindowSize, int myBoxSize)
        {
            if (myBoxSize > myWindowSize)
                throw new ArgumentException("box is bigger than window wah");
            Size = myWindowSize;
            MyBox = new Box(myBoxSize);
        }
        public void UpdateBoxSize(int newSize)
        {
            if (newSize > Size)
                throw new ArgumentException("box is bigger than window wah");
            MyBox.Size = newSize;
        }        
    }
    public class Box
    {
        public int Size { get; set; }
        public Box(int myBoxSize)
        {
            Size = myBoxSize;
        }
    }

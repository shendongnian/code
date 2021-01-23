      public class Window
    {
        private int Size { get; set; }
        private Box MyBox { get; set; }
        public Window(int myWindowSize, int myBoxSize)
        {
            if (myBoxSize > myWindowSize)
                throw new ArgumentException("box is bigger than window wah");
            Size = myWindowSize;
            MyBox = new Box(myBoxSize);
        }
        public Box _getBox()
        {
            return MyBox;
        }
    }
    public class Box
    {
        private int Size { get; set; }
        public Box(int myBoxSize)
        {
            Size = myBoxSize;
        }
    }

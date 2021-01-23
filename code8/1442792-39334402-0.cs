        private int x, y;
        public Point() : this(0, 0) { } //Default-constructor.
        public Point(int X, int Y) //Constructor.
        {
            //this.X = X;
            //this.Y = Y;
            setx(X);
            //this.y = Y;
        }
        public int X //Property for the X-coordinate.
        {
            get { return x; }
            private set
            {
                x = value;
            }
            
        }
        public int Y //Property for the Y-coordinate.
        {
            get { return y; }
        }
        public int setx(int Xvalue)
        {
            return x = Xvalue;
        }
    }

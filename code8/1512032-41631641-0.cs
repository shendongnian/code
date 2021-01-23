    struct Point
    {
        int _x;
        public int X
        {
            get { return _x; }
            set { _x = value; ForceValidate(); }
        } // simple getter & setter for X 
    
        int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; ForceValidate(); }
        } // simple getter & setter for Y
    
        void ForceValidate()
        {
            const MAX = 1000;
            const MIN = -1000;
            if(this.X >= MIN && this.X <= MAX && this.Y >= MIN && this.Y <= MAX)
            {
                return;
            }
            this = default(Point); // Yes you can reasign "this" in structs using C# 
        }
    }

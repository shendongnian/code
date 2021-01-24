    public class Rectangle
    {
        protected int _length;
        protected int _breadth;
        public virtual int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public virtual int Breadth {
            get { return _breadth; }
            set { _breadth = value; }
        }
        public int Area()
        {
            return Length * Breadth;
        }
    }
    public class Square : Rectangle
    {
        
        public override int Breadth
        {
            get { return _breadth; }
            set { _breadth = value;
                _length = _breadth;
            }
        }
        public override int Length {
            get { return _length; }
            set { _length = value;
                _breadth = _length;
            }
        }
    }

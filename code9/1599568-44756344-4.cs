    class Square : IFigures
    {
        int _CsS;
        public Square(int c) 
        {
             CS = c;
        }
    
        public int getarea
        {
            get
            {
                return (_CsS * _CsS);
            }
        }
        public int getperm
        {
            get
            {
                return (2 * _CsS * _CsS);
            }
        }
        public int CS
        {
            set
            {
                _CsS = value;
            }
        }
    
        public void display()
        {
            Console.WriteLine("area={0} and perimeter={1}", getarea, getperm);
        }
        //here you have implemented properties
    }

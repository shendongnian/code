    class line
    {
        double _x, _y;
    
        double x
        {
            get { return _x; }
            set
            {
                _x = value;
                length();
            }
        }
    
        double y
        {
            get { return _y; }
            set
            {
                _y = value;
                length();
            }
        }
    
        double l; // The length of the line
    
        void length()
        {
            l = Math.Sqrt(_x * _x + _y * _y);
        }
    }

    class Sample
    {
        private int _Property;
        private int _ID;
        public int Property
        {
            get { return _Property; }          
        }
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                _Property = value;
            }
        }
    }

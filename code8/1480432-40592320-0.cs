    class FoodItem
    {
        string _name;       
        int _numberserved;
        public FoodItem(string name)
        {
            _name = name;
            _numberserved = 0;
        }
        public FoodItem(string name, int numberserved)
        {
            _name = name;
            NumberServed = numberserved;
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public int NumberServed
        {
            get
            {
                return _numberserved;
            }
            set
            {
                if (value > 4)
                {
                    _numberserved = 4;
                }
                else
                {
                    _numberserved = value;
                }
            }
        }
    }    

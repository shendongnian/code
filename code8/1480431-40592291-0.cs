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
    }

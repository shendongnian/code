    class Person
    {
        private string _name;
        
        public Person(string input)
        {
            _name = input;
        }
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }

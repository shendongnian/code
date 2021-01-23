    public class Person
    {
        protected string _name;
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        
        public Person()
        {
            _name = null;
        }
        public Person(string name)
        {
            _name = name;
        }
        
        public override string ToString()
        {
            return _name;
        }
    }

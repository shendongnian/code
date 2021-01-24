    class MyClass
    {
        private readonly string _name;
        private readonly int _id;
        private readonly double _optional;
        public MyClass(object o)
        {
            _name = o.Peek<string>("Name");
            _id = o.Peek<int>("ID");
            _optional = o.Peek<double>("Optional");
        }
        public void ProveThatItWorked()
        {
            Console.WriteLine(String.Format("ID = '{0}' Name = '{1}' Optional='{2}'", _id, _name, _optional));
        }
    }

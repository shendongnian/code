    class MyClass
    {
        private object _property1;
        private object _property2;
        public object Property1 
        { 
            get
            {
                return _property1; 
            }
            set
            {
                Console.WriteLine("Property1 set");
                _property1 = value;
            }
        }
        public object Property2 
        {
            get
            {
                return _property2;
            }
            set
            {
                Console.WriteLine("Property2 set");
                _property2 = value;
            }
        }
    }
This is approximately what is generated, when you use the public object Property { get; 
set; } syntax. Except for the Console.WriteLine

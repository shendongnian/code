    Class MyClass()
    {
        public object Property { get; set; }
        public void myMethod()
        {
            Property = null; // allowed
        }
    }

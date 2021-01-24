    class Example
    {
        Dictionary<string, SomeClass> _objects = new Dictionary<string, SomeClass>();
        public SomeClass()
        {
            _objects["A"] = new SomeClass();
            _objects["B"] = new SomeClass();
        }
        void CallObjectMethod(string key)
        {
            _objects[key].CommonMethod();
        }
    }

    class Example
    {
        Dictionary<SomeClass> _objects = new Dictionary<SomeClass>();
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

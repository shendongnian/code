        public PropertyInfo[] Properties
        {
            get { return typeof(MyClass).GetProperties(); }
        }
        public MyClass MyObject
        {
            get { return new MyClass { PropertyTest1 = "test", PropertyTest3 = "Some string", PropertyTest4 = "Last Property" }; }
        }

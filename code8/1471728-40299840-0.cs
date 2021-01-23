    class Base {    
    
    }
    class Derived : Base {
        public int IntProperty { get; set; }
        public int CalculateSomething ()
        {
             return IntProperty * 23;
        }
    }

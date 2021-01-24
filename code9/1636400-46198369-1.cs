    class A
    {
        public A(A a)
        {
            // Copy your A class elements here
        }
    }
    class B : A
    {
        public String NewField;
    
        public B(A baseItem, String value)
         : base(baseItem)
        {
            NewField = value;
        }
    }

    class A
    {
        public virtual void Display()
        {
            Console.WriteLine("I am Class A");
        }
        
        public int MyIntValue { get{ return 5; } }
    }
    class B : A
    {
        public override void Display()
        {
            Console.WriteLine("I am class B");
        }
        
        public new int MyIntValue { get{ return 5; } }
    }

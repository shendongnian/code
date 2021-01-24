    abstract class C
    {
        public C(int foo)
        {
            Console.WriteLine("C()");
        }
    }
    
    abstract class B : C
    {
        public B()
    		: base(0 /* foo must be provided */)
        {
            Console.WriteLine("B()");
        }
    }

    class B
    {
        public virtual void foo(B obj)
        {
            Console.WriteLine("B1 ");
        }
    
        public virtual void foo(C obj)
        {
            Console.WriteLine("B1 ");
        }
    }
    
    class C : B
    {
        public override void foo(B obj)
        {
            Console.WriteLine("C1 ");
        }
    
        public override void foo(C obj)
        {
            Console.WriteLine("C1 ");
        }
    }

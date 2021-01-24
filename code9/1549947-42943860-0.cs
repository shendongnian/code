    class A
    {
        public int ai = 1;
        public virtual void Print()
        {
            Console.WriteLine("I am A");
        }
    }
    class B : A
    {
        public int bi = 2;
        public override void Print()
        {
            bi++;
            Console.WriteLine("I am B");
        }
    }
    A a1 = new B();
    a1.Print();
    Console.WriteLine(a1.ai);
    Console.WriteLine(((B)a1).bi);

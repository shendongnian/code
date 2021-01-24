    class A
    {
        private int i = 1;
        public virtual int I
        {
            get { return i; }
        }
        public virtual void Print()
        {
            Console.WriteLine("I am A");
        }
    }
    class B : A
    {
        private int i = 2;
        public override int I
        {
            get { return i; }
        }
        public override void Print()
        {
            i++;
            Console.WriteLine("I am B");
        }
    }
    A a1 = new B();
    a1.Print();
    Console.WriteLine(a1.I);
    Console.WriteLine(((B)a1).I);

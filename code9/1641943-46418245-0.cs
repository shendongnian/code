    class A
    {
        class B
        {
            public void M() { }
        }
        public static object GetB() { return new B(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            dynamic o = A.GetB();
            o.M();
        }
    }

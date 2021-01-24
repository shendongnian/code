    class Program
    {
        static void Main(string[] args)
        {
            A b = new B(), c = new C();
            M(b);
            M(c);
        }
        static void M(A a)
        {
            WriteLine("M(A)");
            M((dynamic)a);
        }
        static void M(B b)
        {
            WriteLine("M(B)");
        }
        static void M(C c)
        {
            WriteLine("M(C)");
        }
    }
    class A { }
    class B : A { }
    class C : A { }

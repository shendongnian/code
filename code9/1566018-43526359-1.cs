    public class A
    {
        public B SomeB { get; set; }
        public int SomeInt { get; set; }
    }
    public class B
    {
        public int SomeVar { get; set; }
        public A SomeA { get; set; }
    }
    static void Main(string[] args)
    {
            A a = new A();
            a.SomeB = new B();
            a.SomeB.SomeA = a;
    }

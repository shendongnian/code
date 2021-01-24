    public abstract class SomeClass
    {
        public abstract string DoSomething();
    }
    public abstract class A
    {
        private class B : SomeClass
        {
            public override string DoSomething()
            {
                return "Something is done in B";
            }
        }
        public static SomeClass CreateB()
        {
            SomeClass sc = new B();
            return sc;
        }
    }
    public  static class Program
    {
       public static void Main()
        {
            var b = A.CreateB();
            Console.WriteLine(b.DoSomething());
        }
    }

    class P
    {
        static void Main() => Console.WriteLine(A.B.Create().GetType());
    }
    public abstract class A
    {
        public class B : A
        {
            private B() { }
            public static B Create() => new B();
        }
    }

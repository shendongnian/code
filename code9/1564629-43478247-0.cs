    namespace Test
    {
        public class Program
        {
            public static void Main()
            {
                Func<int> x = Foo; // want to map Foo to one of the methods below!
            }
            private static int Foo() => 7;
            private static int Foo(int x) => 8
        }
    }

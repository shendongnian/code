    internal class Program
    {
        public static int Method1()
        {
            return new Random(0).Next(10000);
        }
        public class MyClass
        {
            private int var = 11111;
            public int GetSome(int val)
            {
                return var * val;
            }
        }
        private static void Main()
        {
            var clas = new MyClass();
            int a = 111;
            int b = 222;
            Expression<Func<int>> expr = () => a * 2 - clas.GetSome(b) + b + 1 - Method1();
            var result = InvokeAndLog(expr);
        }
        private static T InvokeAndLog<T>(Expression<Func<T>> expr)
        {
            var visitor = new ArgumentsVisitor();
            visitor.Visit(expr);
            Console.WriteLine("Inputs: {0}", string.Join(", ", visitor.Arguments));
            return expr.Compile()();
        }
    }

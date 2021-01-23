    public class Program
    {
        public static void Main(string[] args)
        {
            var values = GetParams(() => Test(1, 2));
            foreach (var v in values)
                System.Diagnostics.Debug.Print(v.ToString());
        }
        private object[] GetParams<T>(Expression<Func<T>> expr)
        {
            var body = (MethodCallExpression)expr.Body;
            var args = body.Arguments;
            return args.Select(p => ((ConstantExpression)p).Value).ToArray();
        }
        public int Test(int arg1, int arg2)
        {
            return arg1 + arg2;
        }
    }

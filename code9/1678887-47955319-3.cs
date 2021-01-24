    class Program
    {
        static void Main(string[] args)
        {
            int result = Execute(() => Foo(1, 2));
        }
        public static int Foo(int x, int y)
        {
            return x + y;
        }
        public static T Execute<T>(Expression<Func<T>> function)
        {
            var call = function.Body as MethodCallExpression;
            var values = new List<object>();
            var obj = call.Object == null ? null : Expression.Lambda(call.Object).Compile().DynamicInvoke();
            foreach (var arg in call.Arguments)
            {
                var value = Expression.Lambda(arg).Compile().DynamicInvoke();
                values.Add(value);
            }
            LogMethodCall(call.Method.Name, values);
            return (T)call.Method.Invoke(obj, values.ToArray());
        }
        public static void LogMethodCall(string methodName, IEnumerable<object> args)
        {
            Console.WriteLine("{0}: {1}", methodName, string.Join(",",args.Select(x=> x.ToString())));
        }
    }

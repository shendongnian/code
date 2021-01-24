    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args) {
                var method = typeof(Program).GetMethod("Method", BindingFlags.Static | BindingFlags.Public);
                var parameter = Expression.Parameter(typeof(int), "n");
                var add = Expression.Add(Expression.Constant(2, typeof(int)), parameter);
                var methodCallExpression = Expression.Call(null, method, add);
                var lambda = Expression.Lambda<Func<int, int>>(methodCallExpression, parameter);
                var func = lambda.Compile();
                Console.WriteLine(func(3));
            }
            public static int Method(int n) => n;
        }
    }

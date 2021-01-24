    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    namespace Test
    {
        class MethodCallVisitor : ExpressionVisitor
        {
            private readonly int toAdd;
            public MethodCallVisitor(int toAdd) {
                this.toAdd = toAdd;
            }
            protected override Expression VisitMethodCall(MethodCallExpression node) {
                var add = Expression.Add(node.Arguments.First(), Expression.Constant(toAdd));
                return Expression.Call(node.Object, node.Method, add);
            }
        }
        class Program
        {
            static void Main(string[] args) {
                var methodCallVisitor = new MethodCallVisitor(2);
                var method = typeof(Program).GetMethod("Method", BindingFlags.Static | BindingFlags.Public);
                var parameter = Expression.Parameter(typeof(int), "n");
                var methodCallExpression = Expression.Call(null, method, parameter);
                var lambda = Expression.Lambda<Func<int, int>>(methodCallExpression, parameter);
                lambda = (Expression<Func<int, int>>)methodCallVisitor.Visit(lambda);
                var func = lambda.Compile();
                Console.WriteLine(func(3));
            }
            public static int Method(int n) => n;
        }
    }

    using System;
    using System.Linq;
    using System.Linq.Expressions;
    namespace Name
    {
        class MyClass
        {
            public int MyProperty { get; set; }
            public MyClass Foo { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(new MyClass().NameOf(m => m.MyProperty));//MyProperty
                Console.WriteLine(new MyClass().NameOf(m => m.Foo.MyProperty));//Foo.MyProperty
                Console.ReadLine();
            }
        }
        public static class MyExtentions
        {
            public static string NameOf<T, TProperty>(this T t, Expression<Func<T, TProperty>> expr)
            {
                return string.Join(".", expr.ToString().Split('.').Skip(1));
            }
        }
    }

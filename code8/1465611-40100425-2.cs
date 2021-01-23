    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Reflection;
    
    namespace ConsoleApp1Core
    {
        [AttributeUsage(AttributeTargets.All)]
        public class MyCustomAttribute : Attribute
        {
            public string SomeProperty { get; set; }
        }
    
    
        public class Foo
        {
            [MyCustom(SomeProperty = "bar")]
            internal static void fn()
            {
                Console.WriteLine("a function in a class");
            }
    
            [MyCustom(SomeProperty = "bar")]
            internal static void fn2()
            {
                Console.WriteLine("another function in the same class");
            }
        }
    
        public class Foo2
        {
            [MyCustom(SomeProperty = "bar")]
            internal static void fn2()
            {
                Console.WriteLine("another function in a nother class");
            }
        }
    
    
        public class Program
        {
            public static int Main(string[] args)
            {
                var targetClasses = new HashSet<string>(new[] { "ConsoleApp1Core.Foo", "ConsoleApp1Core.Foo2" });
                var targetFns = new HashSet<string>(new[] { "fn", "fn2", "fn3" });
                var j = 0;
                foreach (var target in targetClasses)
                {
                    Console.WriteLine("_class round {0}", j++);
                    var i = 0;
                    foreach (var fn in targetFns)
                    {
                        Console.WriteLine("fn round {0}", i++);
                        Type t = Type.GetType(target);
                        var method = (t.GetTypeInfo()) // (typeof(Foo).GetTypeInfo())
                          .DeclaredMethods.Where(x => x.Name == fn).FirstOrDefault();
                        if (method != null) //return 0;
                        {
                            var customAttributes = (MyCustomAttribute[])method
                                                   .GetCustomAttributes(typeof(MyCustomAttribute), true);
                            if (customAttributes.Length > 0)
                            {
                                var myAttribute = customAttributes[0];
                                string value = myAttribute.SomeProperty;
                                if (value == "bar")
                                    method.Invoke(null, null);
                                //  Foo.fn();;
                                else
                                    Console.WriteLine("The attribute parameter is not as required");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Method not found");
                        }
    
                    }
                }
                return 0;
            }
        }
    }

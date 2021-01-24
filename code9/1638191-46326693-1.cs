    using System;
    using System.Reflection;
    namespace ReflectionTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Assembly assembly = Assembly.ReflectionOnlyLoad("ClassLibrary1");
                    Type bl1Type = assembly.GetType("ClassLibrary1.Bl1");
                    Assembly assembly2 = Assembly.ReflectionOnlyLoad("ClassLibrary2");
                    var types = new[] { assembly2.GetType("ClassLibrary2.MyEnum") };
                    //var types = new[] { typeof(MyEnum) }; //Doesn't work
                    var method = bl1Type.GetMethod("Method1", BindingFlags.Instance | BindingFlags.Public,
                            Type.DefaultBinder, types, null);
                    Console.WriteLine(method == null ? "Method was null" : $"Found {method.Name}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.ReadLine();
            }
        }
    }

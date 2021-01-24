    using System;
    using System.Linq;
    using System.Reflection;
    namespace ReflectionTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Assembly assembly = Assembly.ReflectionOnlyLoad("ClassLibrary1");
                Type bl1Type = assembly.GetType("ClassLibrary1.Bl1");
                var types = new[] { Assembly.ReflectionOnlyLoad(assembly.GetReferencedAssemblies().Single(a => a.Name == "ClassLibrary2").Name).GetType("ClassLibrary2.MyEnum") };
                //var types = new[] {typeof(MyEnum)}; //doesn't work
                var method = bl1Type.GetMethod("Method1", BindingFlags.Instance | BindingFlags.Public, Type.DefaultBinder, types, null);
                Console.WriteLine(method == null ? "Method was null" : $"Found {method.Name}");
                Console.ReadLine();
            }
        }
    }

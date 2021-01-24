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
                    foreach (var referencedAssembly in assembly.GetReferencedAssemblies())
                    {
                        Assembly.ReflectionOnlyLoad(referencedAssembly.Name);
                    }
                    Type bl1Type = assembly.GetType("ClassLibrary1.Bl1");
                    Assembly assembly2 = Assembly.ReflectionOnlyLoad("ClassLibrary2");
                    Type bl2Type = assembly2.GetType("ClassLibrary2.MyEnum");
                    var types = new[] { bl2Type };
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

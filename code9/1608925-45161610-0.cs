    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    
    namespace TypeFinder
    {
        class Program
        {
            static void Main(string[] args)
            {
                // args[0]: Assembly path, args[1] Assembly containing type to find, args[2] Type to find
                Type typeToFind = LoadTypeFrom(args[1], args[2]);
                var forms = Assembly.LoadFrom(args[0]).GetTypes().Where(t => t.IsSubclassOf(typeof(Form)));
                foreach (Type form in forms)
                {
                    var fields = form.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    foreach (FieldInfo fieldInfo in fields)
                    {
                        if (IsSubclassOrSameTypeAs(typeToFind, fieldInfo.FieldType))
                        {
                            Console.Out.WriteLine($"Found type {fieldInfo.FieldType} as IsSubclassOrSameTypeAs of {typeToFind}");
                        }
                    }
                }
                Console.Out.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
    
            private static bool IsSubclassOrSameTypeAs(Type baseType, Type descendant)
            {
                return descendant.IsSubclassOf(baseType) || descendant == baseType;
            }
    
    
            private static Type LoadTypeFrom(string path, string type)
            {
                if (string.IsNullOrEmpty(path))
                {
                    return Type.GetType(type, true, true);
                }
                var assembly = Assembly.LoadFrom(path);
                return assembly.GetType(type, true, true);
            }
    
        }
    }

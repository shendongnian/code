    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    namespace GenericReflection
    {
        class Program
        {
            static void Main()
            {
                Type[] typeArgs = { typeof(SomeClass) };
                var listRef = typeof(List<>);
                var list = Activator.CreateInstance(listRef.MakeGenericType(typeArgs));
                var method = list.GetType().GetMethod("Add", BindingFlags.Public | BindingFlags.Instance, null, typeArgs, null);
                Console.WriteLine(method);
                Console.ReadLine();
            }
        }
    
        internal class SomeClass
        {
        }
    }

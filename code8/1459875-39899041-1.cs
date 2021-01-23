    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public class Base {}
        public class Derived : Base {}
        class Program
        {
            static void Main()
            {
                object[] array = {"String", new Base(), new Derived(), 12345};
                foreach (var item in OfType(array, typeof(Base)))
                    Console.WriteLine(item);
            }
            public static IEnumerable<T> OfType<T>(IEnumerable<T> enumerable, Type type)
            {
                return enumerable.Where(element => type.IsInstanceOfType(element));
            }
        }
    }

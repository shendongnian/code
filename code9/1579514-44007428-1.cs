    namespace ConsoleApp1
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        public class Program
        {
            public static void Main()
            {
                var tuple = (1, 2, 3, 4, 5, 6, 7);
                var items = ToEnumerable(tuple);
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
            private static IEnumerable<object> ToEnumerable(object tuple)
            {
                if (tuple.GetType().GetInterface("ITupleInternal") != null)
                {
                    foreach (var prop in tuple.GetType()
                        .GetFields()
                        .Where(x => x.Name.StartsWith("Item")))
                    {
                        yield return prop.GetValue(tuple);
                    }
                }
                else
                {
                    throw new ArgumentException("Not a tuple!");
                }
            }
        }
    }

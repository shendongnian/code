    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, int>();
            var type = dictionary.GetType();
            foreach (var typeArgument in type.GetGenericArguments())
            {
                // System.String, then System.Int32
                Console.WriteLine(typeArgument);
            }
        }
    }

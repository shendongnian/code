    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, int>();
            var type = dictionary.GetType();
            var genericType = type.GetGenericTypeDefinition();
            foreach (var typeArgument in genericType.GetGenericArguments())
            {
                // TKey, then TValue
                Console.WriteLine(typeArgument);
            }
        }
    }

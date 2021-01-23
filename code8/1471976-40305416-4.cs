    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Testing System.Type.IsAssignableFrom");
    
                var propValue = new Dictionary<string, string>() { { "hello", "world" } };
                IDictionary asDict = propValue as IDictionary;
                if (asDict != null)
                {
                    foreach (DictionaryEntry kvp in (IDictionary)propValue)
                    {
                        Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
                    }
                }
    
                Console.ReadLine();
            }
        }
    }

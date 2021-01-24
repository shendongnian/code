    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list = new List<string> {"foo", "bar"};
    
                var tags = new {tags = list};
    
                Console.WriteLine(JsonConvert.SerializeObject(tags));
    
                Console.ReadLine();
            }
        }
    }

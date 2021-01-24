    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    
    public class Test
    {
        static void Main()
        {
            string json = "[{'Key':'x','Value':'y'},{'Key':'a','Value':'b'}]";
            
            var dictionary = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(json)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            
            Console.WriteLine(dictionary["x"]); // y
            Console.WriteLine(dictionary["a"]); // b
        }
    }

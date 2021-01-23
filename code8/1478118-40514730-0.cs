    using System;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    
    public class Test
    {
        static void Main()
        {
            JObject original = JObject.Parse("{ \"x\": \"a\", \"y\": \"b\", \"z\": 1 }");
            var properties = original
                .Properties()
                .Where(p => p.Value.Type == JTokenType.String)
                .ToList();
            
            var recreated = new JObject(properties);
            Console.WriteLine(recreated);
        }
    }

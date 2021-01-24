    using System;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main(string[] args)
        {
            string response = "\"-1\"";
            JToken token = JToken.Parse(response);
            int value = (int) token;
            Console.WriteLine(value);
        }
    }

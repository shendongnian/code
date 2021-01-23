    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main()
        {
            string json = File.ReadAllText("test.json");
            JArray array = JArray.Parse(json);
            List<string> hashes = array.Select(o => (string) o["sha"]).ToList();
            foreach (var hash in hashes)
            {
                Console.WriteLine(hash);
            }
        }
    }

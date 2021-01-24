    using Newtonsoft.Json;
    using System;
    using System.IO;
    namespace SO47114632Core
    {
        class Program
        {
            static void Main(string[] args)
            {
                var content = File.ReadAllText("test.json");
                dynamic json = JsonConvert.DeserializeObject(content);
                Console.WriteLine(json.result);
            }
        }
    }

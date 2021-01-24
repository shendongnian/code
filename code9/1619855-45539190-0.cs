    using System;
    using System.Reflection;
    using Newtonsoft.Json;
    
    namespace ProjectA
    {
        class Program
        {
            static void Main(string[] args)
            {
                object product = new
                {
                    Name = "Apple",
                    Expiry = new DateTime(2008, 12, 28),
                    Sizes = new string[] {"Small"}
                };
    
                string json = JsonConvert.SerializeObject(product);
                Assembly assembly = Assembly.LoadFrom("Newtonsoft.Json.dll");
                Console.WriteLine($"Using version {assembly.GetName().Version}");
                Console.WriteLine($"Serialize just fine: {json}");
                Console.ReadKey();
            }
        }
    }

    using System;
    using System.Configuration;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Configuration.ConfigurationManager.AppSettings["key1"] = "changed";
    
                var value = System.Configuration.ConfigurationManager.AppSettings["key1"];
    
                Console.WriteLine($"This is the new key: {value}.");
            }
        }
    }

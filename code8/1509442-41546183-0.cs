    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                var searchList = new List<string> { "ア", "イ", "ウ", "エ", "オ" };
    
                var fullNameList = new List<string>
                {
                    "Alpha",
                    "アBravo",
                    "Charlie",
                    "イDelta",
                    "Echo",
                    "エFoxtrot",
                    "Golf"
                };
    
                var finds = from name in fullNameList
                            from firstName in searchList
                            where name.StartsWith(firstName)
                            select name;
    
                foreach (string str in finds)
                    Console.WriteLine(str);
    
                Console.ReadKey();
            }
        }
    }
    

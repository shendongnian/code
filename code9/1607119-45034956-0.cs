    using System;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static string GetEscapeSequence(char c)
            {
                return "\\u" + ((int)c).ToString("X4");
            }
    
            static void Main(string[] args)
            {
                var name = "AutoIncrementТаg";
                var currentType = "AutoIncrementTag";
    
                foreach (var character in name)
                {
                    Console.WriteLine(GetEscapeSequence(character));
                }
    
                Console.WriteLine("second string");
                foreach (var character in currentType)
                {
                    Console.WriteLine(GetEscapeSequence(character));
                }
    
                Console.ReadLine();
            }
        }
    }

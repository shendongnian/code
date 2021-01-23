    //Rextester.Program.Main is the entry point for your code. Don't change it.
    //Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
    
    using System;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var input = "hello 4";
                // var input = "4";
                int number;
                var isNumber = int.TryParse(input, out number);
                if (isNumber)
                {
                    if (number == 4)
                    {
                        Console.WriteLine("The Number is 4");
                    }
                    else
                    {
                        Console.WriteLine("The Number isn't 4");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid number");
                }
            }
        }
    }

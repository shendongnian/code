    namespace Malathi
    {
        using System;
    
        class Program
        {
            static void Main()
            {
                string input = string.Empty;
                Console.WriteLine("Enter string wants to reverse");
                input = Console.ReadLine();
    
                char[] inputarray = input.ToCharArray();
                string reverse = string.Empty;
                for (int i = inputarray.Length - 1; i >= 0; i--)
                {
                    reverse += inputarray[i];
                }
                Console.WriteLine("Reverse string {0}", reverse);
                Console.ReadLine();
            }
        }
    }

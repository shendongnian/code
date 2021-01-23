    using System;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the string: ");
            string inputString = Console.ReadLine();
            string outputString = string.Join(" ", inputString.Split(' ').Select(x=> new string(x.Reverse().ToArray())));
            Console.WriteLine("Output: "+ outputString);
            Console.ReadKey();
        }
    }

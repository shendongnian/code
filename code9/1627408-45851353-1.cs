    using System;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string a = "One";
                string b = "Two";
                string c = "Three";
                string abc = string.Join(", ", a, b, c);
                Console.WriteLine(abc); //One, Two, Three
            }
        }
    }

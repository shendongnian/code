    using System;
    using System.Collections.Generic;
    namespace ConsoleApp
    {
        class Program
        {
            static List<string> alphabet = new List<string>() {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };
            static void Main(string[] args)
            {
                string text = "aaaaaaaaaaaaaaa";
                for (int i = 0; i < text.Length; i++)
                {
                    int value = alphabet.IndexOf(Convert.ToString(text[i]));
                    Console.Write(value);
                }
                Console.ReadLine();
            }
        }
    }

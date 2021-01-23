    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace RandomWords
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string[] words = new[] { "csharp", "Stack", "overflow", "microsoft", "word5", "Coding"};
                Random rnum = new Random();
                string input = null;
                while ( input != "end") {
                    int intnum = rnum.Next(0, words.Length);
                    Console.WriteLine("Guess a word or enter end to exit");
                    input = Console.ReadLine();
                  List<string> l =  words.Where(x => x == input).ToList<string>();
                  if (l.Count != 0) { Console.WriteLine("Congratulations you have won! Your words are a match"); } else { Console.WriteLine("Sorry but your words are not a match, try again"); }
                }
    
            }
        }
    }

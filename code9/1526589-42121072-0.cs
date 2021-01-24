    using System.Text.RegularExpressions;
    
    namespace StackOverCSharp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("enter your text here");
                string text = Convert.ToString(Console.ReadLine());
                MatchCollection collection = Regex.Matches(text, @"[\S]+");
                
                Console.WriteLine(collection.Count);
            }
        }
    }

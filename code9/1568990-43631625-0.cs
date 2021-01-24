    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        private static readonly Regex TextInBrackets = new Regex(@"^(\[[^\]]*\] )*");
        
        public static void Main()
        {
            var input = new[]
            {
                "[Unfinished] Project task 1 bit",
                "Some other Piece of work to do",
                "[Continued] [Unfinished] Project task 1",
                "Project Task 2",
                "Random other work to do",
                "Project 4",
                "[Continued] [Continued] Project task 1",
                "[SPIKE] Investigate the foo",
            };
            
            var ordered = input.OrderBy(RemoveTextInBrackets);
            
            foreach (var item in ordered)
            {
                Console.WriteLine(item);
            }
        }
    
        static string RemoveTextInBrackets(string input) =>
            TextInBrackets.Replace(input, "");
    }

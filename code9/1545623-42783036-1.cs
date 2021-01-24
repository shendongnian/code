    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication9
    {
      internal static class Program
      {
        private static void Main()
        {
          //  --- building up the data so the next (repeated) steps are efficient: ---
    
          // your words and points
          var wordHolder = new Dictionary<string, int>();
    
          // INSERT DATA INTO wordHolder HERE
    
          // create a dictionary where you can access all words and their points 
          // efficiently by the letters you have available:
          var efficientAccessByLetters = wordHolder.Select(entry =>
                                                    new
                                                    {
                                                      Index = new string(entry.Key.OrderBy(c => c).ToArray()),
                                                      Word = entry.Key,
                                                      Points = entry.Value
                                                    })
                                                    .GroupBy(x => x.Index)
                                                    .ToDictionary(x => x.Key,
                                                                  x => x.OrderBy(p => p.Points).ToList());
    
          //  --- Repeat this steps as many times as you like: ---
    
          while (true)
          {
            Console.WriteLine("Enter letters available:");
    
            // get letters that you want to build he best word from:
            var availableLetters = Console.ReadLine();
    
            // normalize the letters for fast index search by sorting them
            var normalized = new string(availableLetters.OrderBy(c => c).ToArray());
    
            if (!efficientAccessByLetters.ContainsKey(normalized))
            {
              Console.WriteLine("Sorry, no matching words found.");
            }
            else
            {
              // find all words and their respective points by index access
              var wordsThatMatchLetters = efficientAccessByLetters[normalized];
    
              // as words are sorted by points, just get the first
              var best = wordsThatMatchLetters.First();
    
              // output
              Console.WriteLine("Best Match: {0} for {1} points", best.Word, best.Points);
            }
          }
        }
      }
    }

    using System.Collections.Generic;
    namespace TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var pickList = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};
                while (pickList.Count > 1)
                {
                   Console.WriteLine(
                      "Hit any key to get Random pair of integers from List.");
                   Console.ReadLine();
                   var pair = GetPairFromList(pickList);
                   Console.WriteLine($"Pair is: {pair.Item1}: {pair.Item2}");
                }
                Console.WriteLine("List is empty; Hit any key to exit.");
                Console.ReadLine();
            }
            private static Tuple<int, int> GetPairFromList(IList<int> picks)
            {
                return new Tuple<int, int>(
                    GetIntFromList(picks), 
                    GetIntFromList(picks));
            }
            private static int GetIntFromList(IList<int> picks)
            {
                var rand = new Random(DateTime.Now.Millisecond);
                // next line is where random picking happens
                var val = picks[(int)(picks.Count*rand.NextDouble())];
                picks.Remove(val);
                return val;
            }
        }
    }

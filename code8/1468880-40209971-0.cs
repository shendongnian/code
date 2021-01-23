    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Take3Distinct take3Distinct = new Take3Distinct();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(string.Join(",", take3Distinct.Take3().ToArray()));
                }
                Console.ReadLine();
            }
        }
        public class Take3Distinct
        {
            const int SIZE = 6;
            Random rand = new Random();
            public List<List<int>> pairs = new List<List<int>>();
            public Take3Distinct()
            {
                for(int i = 1; i <= SIZE; i++)
                {
                    List<int> newPair = new List<int>{i, 0};
                    pairs.Add(newPair);
                }
            }
            public List<int> Take3()
            {
                foreach (List<int> pair in pairs)
                {
                    pair[1] = rand.Next();
                }
                pairs = pairs.OrderBy(x => x[1]).ToList();
                return pairs.Select(x => x[0]).Take(3).ToList();
            }
        }
    }

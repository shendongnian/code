    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            class IndexPair
            {
                public int Index1 { get; set; }
                public int Index2 { get; set; }
            }
    
            static void Main(string[] args)
            {
                var testString = "spring java spring spring spring javescript java jboss jboss tomcat jboss";
                var test = testString.Split(' ');
                var pairs = new List<IndexPair>();
                var comboPairs = new List<IndexPair>();
    
                for (int i = 0; i < test.Length; i++)
                    for (int j = 0; j < test.Length; j++)
                        if (j > i && test[i] == test[j])
                        {
                            var pair = new IndexPair { Index1 = i, Index2 = j };
                            pairs.Add(pair);
    
                            if (j == (i + 1)) comboPairs.Add(pair);
                        }
    
                Console.WriteLine("Intpu string: " + testString);
                Console.WriteLine("Word pairs: " + string.Join(" ", pairs.Select(p => $"{p.Index1},{p.Index2}")));
                Console.WriteLine("Combo pairs: " + string.Join(" ", comboPairs.Select(p => $"{p.Index1},{p.Index2}")));
                Console.ReadKey();
            }
        }
    }

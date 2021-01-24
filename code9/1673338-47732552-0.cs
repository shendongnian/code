    using System;
    using System.Collections.Generic;
    
    namespace KvpSequence
    {
        class Program
        {
            const int numberOfSequences = 4; // each sequence is a set of 4 ints between 1 and 5
            static void Main(string[] args)
            {
                List<KeyValuePair<int, int>> sequence = new List<KeyValuePair<int, int>>(numberOfSequences * 4);
                Random rand = new Random();
    
                for (int i = 0; i < numberOfSequences; ++i) {
                    var indexToSet = rand.Next(0, 4);
                    for (int j = 0; j < 4; ++j)
                        sequence.Add(new KeyValuePair<int, int>(rand.Next(1, 6), j == indexToSet ? 1 : 0));
                }
    
                foreach (var kvp in sequence)
                    Console.WriteLine(kvp);
            }
        }
    }

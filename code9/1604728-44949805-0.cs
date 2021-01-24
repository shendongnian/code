    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var inputData = new [] {
                      new[] { 1, 2, 3},
                      new[] { 3, 4, 5},
                      new[] { 5, 4, 3},
                    };
    
                var values = GetTotalsPerColumn(inputData);
    
                foreach (var value in values)
                {
                    Console.WriteLine(value.Key + " - " + value.Value);
                }
    
                Console.ReadLine();
            }
    
            private static Dictionary<int, int> GetTotalsPerColumn(int[][] inputData)
            {
                var values = new Dictionary<int, int>();
    
                foreach (var line in inputData)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        int tempValue;
    
                        values.TryGetValue(i, out tempValue);
                        tempValue += line[i];
                        values[i] = tempValue;
                    }
                }
                return values;
            }
        }
    }

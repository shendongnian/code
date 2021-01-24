    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Testing
    {
        public class DoubleString
        {
            public string P1 { get; set; }
            public string P2 { get; set; }     
        }
        class Program
        {
            static void Main(string[] args)
            {
                var list1 = new List<string>()
                {
                    "A",
                    "A",
                    "A",
                    "B"
                };
                var list2 = new List<string>()
                {
                    "A",
                    "B",
                    "B"
                };
                var allLetters = list1.Union(list2).Distinct().ToList();
            
                var result = new List<DoubleString>();
                foreach (var letter in allLetters)
                {
                    var list1Count = list1.Count(l => l == letter);
                    var list2Count = list2.Count(l => l == letter);
                    var matchCount = Math.Min(list1Count, list2Count);
                    addValuesToResult(result, letter, letter, matchCount);
                    var difference = list1Count - list2Count;
                    if(difference > 0)
                    {
                        addValuesToResult(result, letter, null, difference);                   
                    }
                    else
                    {
                        difference = difference * -1;
                        addValuesToResult(result,null, letter, difference);                   
                    }
                }
                foreach(var res in result)
               {
                    Console.WriteLine(res.P1 + " " + res.P2);
                }
                Console.ReadLine();
            
            }
            private static void addValuesToResult(List<DoubleString> result, 
    string letter1, string letter2, int count)
            {
                for (int i = 0; i < count; i++)
                {
                    result.Add(new DoubleString
                   {
                        P1 = letter1,
                        P2 = letter2
                    });
                }
            }
        }
    }

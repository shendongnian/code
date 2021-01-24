    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    
    public class Test
    {
        public string YearMonth {get;set;}
        public string Branch {get;set;}
        public string CIRef {get;set;}
        public int Count {get;set;}
    }
    
    class Program
    {
        static void Main()
        {
            List<Test> Tests = new List<Test>
            {
                new Test
                {
                    YearMonth = "17/05",
                    Branch = "Perth",
                    CIRef = "TerryTaylors",
                    Count = 22
                },
                new Test
                {
                    YearMonth = "17/05",
                    Branch = "Perth",
                    CIRef = "TimmyToolies",
                    Count = 33
                },
                new Test
                {
                    YearMonth = "17/05",
                    Branch = "Perth",
                    CIRef = "BillyBobbies",
                    Count = 42
                },
                new Test
                {
                    YearMonth = "17/05",
                    Branch = "Sydney",
                    CIRef = "RinkleRankles",
                    Count = 10
                },
                new Test
                {
                    YearMonth = "17/05",
                    Branch = "Melbourne",
                    CIRef = "PinkyPonkies",
                    Count = 19
                },
                new Test
                {
                    YearMonth = "17/05",
                    Branch = "Melbourne",
                    CIRef = "JanglyJunglies",
                    Count = 11
                },
                new Test
                {
                    YearMonth = "18/05",
                    Branch = "Perth",
                    CIRef = "TerryTaylors",
                    Count = 9
                },
                new Test
                {
                    YearMonth = "18/05",
                    Branch = "Perth",
                    CIRef = "TimmyToolies",
                    Count = 2
                },
                new Test
                {
                    YearMonth = "18/05",
                    Branch = "Perth",
                    CIRef = "BillyBobbies",
                    Count = 1
                },
                new Test
                {
                    YearMonth = "18/05",
                    Branch = "Sydney",
                    CIRef = "RinkleRankles",
                    Count = 15
                },
                new Test
                {
                    YearMonth = "18/05",
                    Branch = "Melbourne",
                    CIRef = "PinkyPonkies",
                    Count = 61
                },
                new Test
                {
                    YearMonth = "18/05",
                    Branch = "Melbourne",
                    CIRef = "JanglyJunglies",
                    Count = 99
                }
            };
            
            var groupedBy = Tests.GroupBy(t => t.YearMonth)
                        .SelectMany(o => o.OrderByDescending(x => x.Count).Take(5));
                        
            foreach(var c in groupedBy)
            {
                Console.WriteLine(c.YearMonth + " - " + c.Branch + " - " + c.CIRef + " - " + c.Count);
            }
        }
    }

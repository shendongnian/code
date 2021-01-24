    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication73
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Anonim> invoiced = new List<Anonim> 
                { 
                    new Anonim {Category = 1, Title = "Legal", Amount = 20},
                    new Anonim {Category = 2, Title = "Accounting", Amount = 10}
                };
                List<Anonim> settled = new List<Anonim> {
                    new Anonim {Category = 1, Title = "Legal", Amount = 10}
                };
                List<Anonim> credit = new List<Anonim> {
                    new Anonim {Category = 1, Title = "Legal", Amount = 30},
                    new Anonim {Category = 2, Title = "Accounting", Amount = 20}
                };
                List<Result> results = new List<Result>();
                List<string> titles = invoiced.Select(x => x.Title).ToList();
                titles.AddRange(settled.Select(x => x.Title).ToList());
                titles.AddRange(credit.Select(x => x.Title).ToList();
                titles = titles.Distinct().ToList();
                
                foreach(string title in titles)
                {
                    Result newResult = new Result();
                    results.Add(new Result);
                    newResult.Title = title;
                    newResult.Credit = credit.Where(x => x.Title == title).Sum(x => x.Amount);
                    newResult.Invoiced = invoiced.Where(x => x.Title == title).Sum(x => x.Amount);
                    newResult.Settled = settled.Where(x => x.Title == title).Sum(x => x.Amount);
                    newResult.SumAmount = newResult.Credit + newResult.Invoiced + newResult.Settled;
                }
            }
     
        }
        public class Result
        {
            public string Title { get; set; }
            public decimal Credit { get; set; }
            public decimal Invoiced { get; set; }
            public decimal Settled { get; set; }
            public decimal SumAmount { get; set; }
        }
        public class Anonim
        {
            public int Category { get; set; }
            public string Title { get; set; }
            public decimal Amount { get; set; }
        }
    }

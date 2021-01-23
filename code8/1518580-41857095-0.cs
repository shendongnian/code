    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication43
    {
        class Program
        {
     
            static void Main(string[] args)
            {
                List<MyDate> dates = new List<MyDate>() {
                    new MyDate() { Main = true, StartDate = DateTime.Parse("1/1/17"), EndDate = DateTime.Parse("1/3/17") },
                    new MyDate() { Main = true,                                       EndDate = DateTime.Parse("1/4/17") },
                    new MyDate() { Main = true, StartDate = DateTime.Parse("1/2/17"), EndDate = DateTime.Parse("1/5/17") },
                    new MyDate() { Main = true, StartDate = DateTime.Parse("1/3/17"), EndDate = DateTime.Parse("1/6/17") },
                    new MyDate() { Main = false, StartDate = DateTime.Parse("1/4/17"), EndDate = DateTime.Parse("1/7/17") },
                    new MyDate() { Main = true,                                       EndDate = DateTime.Parse("1/8/17") },
                    new MyDate() { Main = true, StartDate = DateTime.Parse("1/4/17"), EndDate = DateTime.Parse("1/9/17") },
                    new MyDate() { Main = false, StartDate = DateTime.Parse("1/5/17"), EndDate = DateTime.Parse("1/10/17") },
                    new MyDate() { Main = false, StartDate = DateTime.Parse("1/5/17"), EndDate = DateTime.Parse("1/11/17") },
                    new MyDate() { Main = false, StartDate = DateTime.Parse("1/5/17"), EndDate = DateTime.Parse("1/12/17") }
                };
                var results = dates.Select(p => new { key = p.Main == true && p.EndDate == null, date = p })
                    .GroupBy(x => x.key).Select(y => y.GroupBy(z => z.date.StartDate).Select(a => a.OrderBy(b => b.date.EndDate)))
                        .SelectMany(y => y).SelectMany(x => x).Select(p => p.date).ToList();
                foreach(MyDate result in results)
                {
                    Console.WriteLine("{0},{1},{2}",
                        result.Main == null ? "" : result.Main == true ? "true" : "false",
                        result.StartDate.ToString(),
                        result.EndDate.ToString());
                }
                Console.ReadLine();
            }
        }
        public class MyDate
        {
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public bool? Main { get; set; } 
        }
    }

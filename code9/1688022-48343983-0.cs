    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO.Ports;
    using System.Data;
    using System.Xml.Serialization;
    namespace ConsoleApplication20
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Tuple<DateTime, int>> list = new List<Tuple<DateTime,int>>() {
                    new Tuple<DateTime,int>(new DateTime(2018, 1,29),0),
                    new Tuple<DateTime,int>(new DateTime(2018, 1,25),1),
                    new Tuple<DateTime,int>(new DateTime(2018, 1,20),2),
                    new Tuple<DateTime,int>(new DateTime(2018, 1,10),3),
                    new Tuple<DateTime,int>(new DateTime(2018, 1,3),4)
                };
                List<DateTime> searchDates = new List<DateTime>() { new DateTime(2018, 1, 1), new DateTime(2018, 1, 5), new DateTime(2018, 1, 28), new DateTime(2018, 2, 1) };
                foreach(DateTime date in searchDates)
                {
                    int results = BinarySearch(list, date);
                    Console.WriteLine("Input Date : '{0}', index : '{1}'", date.ToShortDateString(), results);
                }
                Console.ReadLine();
            }
            static int BinarySearch(List<Tuple<DateTime, int>> list, DateTime date)
            {
                var results = list.Select(x => new { diff = (x.Item1 - date).Days, index = x.Item2 }).Where(x => x.diff >= 0).OrderBy(x => x.diff).FirstOrDefault();
                return results == null ? -1 : results.index;
            }
     
        }
     
    }

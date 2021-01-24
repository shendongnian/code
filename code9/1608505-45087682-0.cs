    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication65
    {
        class Program
        {
            static void Main(string[] args)
            {
                StockData.data = new List<StockData>() {
                    new StockData() { date = DateTime.Parse("6/17/2015"), high = 256.9},
                    new StockData() { date = DateTime.Parse("6/18/2015"), high = 260.7},
                    new StockData() { date = DateTime.Parse("6/23/2015"), high = 271.2},
                    new StockData() { date = DateTime.Parse("6/24/2015"), high = 267.9},
                    new StockData() { date = DateTime.Parse("6/25/2015"), high = 266},
                    new StockData() { date = DateTime.Parse("6/26/2015"), high = 266.9},
                    new StockData() { date = DateTime.Parse("6/30/2015"), high = 263.35},
                    new StockData() { date = DateTime.Parse("7/8/2015"), high = 271},
                    new StockData() { date = DateTime.Parse("7/10/2015"), high = 271},
                    new StockData() { date = DateTime.Parse("7/13/2015"), high = 274.35},
                    new StockData() { date = DateTime.Parse("7/14/2015"), high = 273.6},
                    new StockData() { date = DateTime.Parse("7/15/2015"), high = 271.7},
                    new StockData() { date = DateTime.Parse("7/16/2015"), high = 272.75}
                };
                UpDownData.data = new List<UpDownData>() {
                    new UpDownData() { date = DateTime.Parse("6/30/2015"), min_max = 263.35},
                    new UpDownData() { date = DateTime.Parse("7/8/2015"), min_max = 250},
                    new UpDownData() { date = DateTime.Parse("7/10/2015"), min_max = 236.65},
                    new UpDownData() { date = DateTime.Parse("7/13/2015"), min_max = 223.3},
                    new UpDownData() { date = DateTime.Parse("7/14/2015"), min_max = 209.95},
                    new UpDownData() { date = DateTime.Parse("7/15/2015"), min_max = 196.6},
                    new UpDownData() { date = DateTime.Parse("7/16/2015"), min_max = 272.75}
                };
                var results = (from sData in StockData.data
                               join uData in UpDownData.data on sData.date equals uData.date
                               select new { sData = sData, uData = uData })
                              .Where(x => x.sData.high == x.uData.min_max)
                              .Select(x => new { date = x.sData.date, value = x.sData.high }).ToList();
            }
        }
        public class StockData
        {
            public static List<StockData> data = new List<StockData>();
            public DateTime date { get; set; }
            public double high { get; set; }
        }
        public class UpDownData
        {
            public static List<UpDownData> data = new List<UpDownData>();
            public DateTime date { get; set; }
            public double min_max { get; set; }
        }
    }

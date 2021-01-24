    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TimeSplit
    {
        class Program
        {
            static void Main(string[] args)
            {
                var range = new DateRange()
                {
                    Start = new DateTime(2017, 08, 05, 09, 00, 00),
                    End = new DateTime(2017, 08, 07, 16, 00, 00)
                };
    
                foreach (var r in SplitInToDays(range))
                {
                    Console.WriteLine($"{r.Start} - {r.End} - {r.Duration}");
                }
                Console.ReadLine();
            }
    
            public static IEnumerable<DateRange> SplitInToDays(DateRange range)
            {
                var ranges = new List<DateRange>();
    
                var tempRange = new DateRange() { Start = range.Start, End = range.End };
    
                while (tempRange.Start.Date != tempRange.End.Date)
                {
                    var dateRange = new DateRange()
                    {
                        Start = tempRange.Start,
                        End = tempRange.Start.Date.AddDays(1)
                    };
                    ranges.Add(dateRange);
                    tempRange.Start = dateRange.End;
                }
    
                ranges.Add(tempRange);
    
                return ranges;
            }
        }
    
        public class DateRange
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
    
            public TimeSpan Duration => End - Start;
        }
    }

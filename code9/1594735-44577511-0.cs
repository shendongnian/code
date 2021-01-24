    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        public class SomeItem
        {
            public int A { get; set; }
            public int B { get; set; }
            public DateTime C { get; set; }
    
            public override string ToString()
            {
                return $"{A} - {B} - {C}";
            }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                // Assuming 2 second margin
                var margin = TimeSpan.FromSeconds(2 * 2);
    
                var input = new List<SomeItem>
                {
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 2)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 4)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 6)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 9)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 11)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 15)}
                };
    
                // IGrouping and ILookup are very similar
                // See the difference at https://stackoverflow.com/questions/1337539/ilookuptkey-tval-vs-igroupingtkey-tval
                var firstGrouping = input.ToLookup(x => new { x.A, x.B });
                var readyForGrouping = new List<dynamic>();
    
                foreach (var grouping in firstGrouping)
                {
                    var firstDate = default(DateTime?);
                    var count = 0;
                    var groupingCount = grouping.Count();
                    
                    while (groupingCount > count)
                    {
                        readyForGrouping.AddRange(grouping.Skip(count).TakeWhile(z =>
                        {
                            if (firstDate == null)
                            {
                                firstDate = z.C;
                                count++;
                                return true;
                            }
                            if (z.C <= firstDate.Value.Add(margin))
                            {
                                count++;
                                return true;
                            }
                            firstDate = z.C;
                            return false;
                        }).Select(z => new { SomeItem = z, GroupingIndicator = firstDate }).ToList());
                    }
                }
    
                var groupedItems = readyForGrouping.GroupBy(x => new {x.SomeItem.A, x.SomeItem.B, x.GroupingIndicator });
    
                foreach (var grouping in groupedItems)
                {
                    Console.WriteLine("Start Of Group");
                    foreach (var entry in grouping)
                    {
                        Console.WriteLine(entry);
    
                    }
                }
                Console.ReadLine();
    
            }
    
        }
    }

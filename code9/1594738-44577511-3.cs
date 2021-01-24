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
                var margin = TimeSpan.FromSeconds(2);
    
                var input = new List<SomeItem>
                {
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 0)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 2)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 4)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 6)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 9)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 11)},
                    new SomeItem() {A = 1, B = 2, C = new DateTime(2017, 6, 15, 0, 0, 15)},
                    new SomeItem() {A = 1, B = 3, C = new DateTime(2017, 6, 15, 0, 0, 2)},
                    new SomeItem() {A = 1, B = 3, C = new DateTime(2017, 6, 15, 0, 0, 4)},
                    new SomeItem() {A = 1, B = 3, C = new DateTime(2017, 6, 15, 0, 0, 6)},
                    new SomeItem() {A = 1, B = 3, C = new DateTime(2017, 6, 15, 0, 0, 9)},
                    new SomeItem() {A = 1, B = 3, C = new DateTime(2017, 6, 15, 0, 0, 11)},
                    new SomeItem() {A = 1, B = 3, C = new DateTime(2017, 6, 15, 0, 0, 13)}
                };
    
                var firstGrouping = input.GroupBy(x => new { x.A, x.B });
                var readyForGrouping = new List<Tuple<SomeItem, int>>();
    
                foreach (var grouping in firstGrouping)
                {
                    var data = grouping.OrderBy(z => z.C).ToList();
                    var lastDate = default(DateTime?);
                    var count = 0;
                    var groupingCount = data.Count();
                    var groupID = 0;
    
                    while (groupingCount > count)
                    {
                        groupID++;
                        readyForGrouping.AddRange(data.Skip(count).TakeWhile(z =>
                        {
                            var old = lastDate;
                            lastDate = z.C;
                            if (old == null)
                            {
                                count++;
                                return true;
                            }
                            if (z.C <= old.Value.Add(margin))
                            {
                                count++;
                                return true;
                            }
                            return false;
                        }).Select(z => new Tuple<SomeItem, int>(z, groupID)).ToList());
                    }
                }
    
                var groupedItems = readyForGrouping.GroupBy(x => new { x.Item1.A, x.Item1.B, x.Item2 },
                    x => x.Item1);
    
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

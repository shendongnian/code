    public class Program
        {
            public class TestData
            {
                public int First { get; set; }
                public int Second { get; set; }
                public int Third { get; set; }
                public int Place { get; set; }
            }
    
            public static void Main(string[] args)
            {
                var data = new List<TestData>
                {
                    new TestData {First = 580, Second = 25, Third = 32},
                    new TestData {First = 560, Second = 30, Third = 30},
                    new TestData {First = 523, Second = 23, Third = 26},
                    new TestData {First = 523, Second = 23, Third = 26},
                    new TestData {First = 523, Second = 23, Third = 26},
                    new TestData {First = 520, Second = 23, Third = 26},
                    new TestData {First = 518, Second = 40, Third = 30},
                    new TestData {First = 518, Second = 40, Third = 30},
                    new TestData {First = 430, Second = 14, Third = 16}
                };
    
                var sorted =
                    (from d in data
                        orderby d.First descending, d.Second descending, d.Third descending 
                        group d by d.First.ToString() + d.Second + d.Third into gd
                        select gd.ToList())
                        .ToList();
    
                var result = new List<TestData>();
                var place = 1;
                foreach (var sd in sorted)
                {
                    sd.ForEach(p => p.Place = place);
                    result.AddRange(sd);
                    place += sd.Count;
                }
            }
        }

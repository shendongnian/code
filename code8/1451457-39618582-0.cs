    public class ExampleClass
    {
        public int Id1 { get; set; }
        public int Id2 { get; set; }
        public int Usage { get; set; }
        public int UsageThis { get; set; }
        public int UsageLast { get; set; }
    }
            List<ExampleClass> listThisMonth = new List<ExampleClass>
            {
                new ExampleClass{Id1=1, Id2=1,Usage=7, UsageThis=1, UsageLast=0},
                new ExampleClass{Id1=2, Id2=2,Usage=4, UsageThis=2, UsageLast=0},
                new ExampleClass{Id1=3, Id2=3,Usage=1, UsageThis=3, UsageLast=0},
            };
            List<ExampleClass> listLastMonth = new List<ExampleClass>
            {
                new ExampleClass{Id1=1, Id2=1,Usage=3, UsageThis=1, UsageLast=1},
                new ExampleClass{Id1=4, Id2=4,Usage=3, UsageThis=4, UsageLast=3},
                new ExampleClass{Id1=2, Id2=2,Usage=1, UsageThis=8, UsageLast=6},
            };
            var result = listThisMonth.Select(a=>new {value=a, list=1})
                .Union(listLastMonth.Select(a => new { value = a, list = 2 }))
                .GroupBy(a => new { Id1 = a.value.Id1, Id2 = a.value.Id2 })
                .Select(x => new ExampleClass
                {
                    Id1 = x.Key.Id1,
                    Id2 = x.Key.Id2,
                    UsageThis = x.Any(o => o.list == 1) ? x.First(o => o.list == 1).value.Usage : 0,
                    UsageLast = x.Any(o => o.list == 2) ? x.First(o => o.list == 2).value.Usage : 0,
                    Usage = x.Sum(o=>o.value.Usage)
                }).ToList();
            //id1   id2 current last    sum
            //1	    1	7	    3	    10
            //2	    2	4	    1	    5
            //3	    3	1	    0	    1
            //4	    4	0	    3	    3

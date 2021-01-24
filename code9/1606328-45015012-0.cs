    static void Main(string[] args)
    {
        var lstFoos = new List<Foo>() {
            new Foo() { Id = 1, DocumentName = "Test2", EffectiveDate = new DateTime(2017, 7, 9), PrintOrder = 2, AscOrDesc = "A" },
            new Foo() { Id = 2, DocumentName = "Test1", EffectiveDate = new DateTime(2017, 5, 5), PrintOrder = 1, AscOrDesc = "D" },
            new Foo() { Id = 3, DocumentName = "Test2", EffectiveDate = new DateTime(2017, 7, 8), PrintOrder = 2, AscOrDesc = "A" },
            new Foo() { Id = 4, DocumentName = "Test3", EffectiveDate = new DateTime(2017, 4, 9), PrintOrder = 3, AscOrDesc = "D" },
            };
    
        var result = lstFoos.OrderBy(x => x.PrintOrder).GroupBy(x => x.DocumentName).SelectMany(x =>
        {
            if (x.Count() > 1)
            {
                var ascOrDesc = x.First().AscOrDesc;
                return new List<Foo>(ascOrDesc == "A" ? x.OrderBy(y => y.EffectiveDate) : x.OrderByDescending(y => y.EffectiveDate));
            }
    
            return new List<Foo>() {x.First()};
        });
    
        foreach (var foo in result)
            Console.WriteLine(foo.ToString());
    
        Console.ReadLine();
    }
    
    public class Foo
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int PrintOrder { get; set; }
        public string AscOrDesc { get; set; }
    
        public override string ToString()
        {
            return $"Id: {Id} | DocumentName: {DocumentName} | EffectiveDate: {EffectiveDate} | PrintOrder: {PrintOrder} | AscOrDesc: {AscOrDesc}";
        }
    }

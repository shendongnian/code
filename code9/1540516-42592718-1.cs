    public class DemoRoughTable
    {
        public int Value { get; set; }
    }
    public class DemoRoughViewModel
    {
        public List<DemoRoughTable> TableA { get; set; } = new List<DemoRoughTable>()
        {
            new DemoRoughTable() { Value =1 }, new DemoRoughTable() { Value =2 }
        };
    }

    public class TestClass
    {
        public IOrderedEnumerable<long> orderedDatas { get; set; }
        public string Name { get; set; }
        public TestClass(string name, params long [] orderedDatas)
        {
            this.Name = name;
            this.orderedDatas = orderedDatas.OrderBy(i => i);
        }
    }

    private struct DataHolder
    {
        public decimal result { set; get; }
        public Package[] Packages { set; get; }
        public bool IsArbitrary { set; get; }
    }
    
    private struct Package
    {
        public decimal Count { set; get; }
        public decimal Price { set; get; }
    }
    
    static void Main(string[] args)
    {
        string html = "{\"Result\":0,\"Packages\":[{\"Count\":5.0,\"Price\":100000},{\"Count\":10.0,\"Price\":170000},{\"Count\":20.0,\"Price\":300000},{\"Count\":50.0,\"Price\":600000},{\"Count\":100.0,\"Price\":900000}],\"IsArbitrary\":true}";
    
        DataHolder data = JsonConvert.DeserializeObject<DataHolder>(html);
    
        foreach(var package in data.Packages)
        {
           // do something with package.Count or package.Price
        }
    }

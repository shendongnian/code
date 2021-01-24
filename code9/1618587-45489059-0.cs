    public class IntermediateTestData
    {
    	public string Name;
    	public List<List<string>> Data;
    }
    
    public class TestData
    {
    	public string Name;
    	public IEnumerable<TestDataItem> Data;
    }
    
    public class TestDataItem
    {
    	public DateTime Date { get; set; }
    	public double Value { get; set; }
    }

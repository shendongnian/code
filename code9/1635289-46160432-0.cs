    [Serializable]
    public class Test<T> where T : class
    {
    	public Test() { }
    
    	public int TestId { get; set; }
    	public string Name { get; set; }
    	public List<T> Shipments { get; set; }
    }
    

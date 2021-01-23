    public class Configuration
    {
    	public bool ValueBit { get; set; }
    	public string ValueText { get; set; }
    	public decimal ValueDecimal { get; set; }
    }
    
    void Main()
    {
    	GetValueBasedOnType<bool>(0).Dump();
    	GetValueBasedOnType<string>(0).Dump();
    	GetValueBasedOnType<decimal>(0).Dump();
    }

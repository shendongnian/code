    class Currency
    {
    	public string Name { get; set; }
    	public string Symbol_Native { get; set; }
    	public int Decimal_Digits { get; set; }
    	public string Code { get; set;}
    }
    
    void Main()
    {
    	var json = File.ReadAllText(@"C:\users\clint\desktop\common-currency.json");
    	var dict = JsonConvert.DeserializeObject<Dictionary<string, Currency>>(json);
    	foreach (var keyValuePair in dict)
    	{
    		Console.WriteLine("Currency: {0}", keyValuePair.Key);
    		Console.WriteLine("\tName: {0}", keyValuePair.Value.Name);
    		Console.WriteLine("\tSymbol_Native: {0}", keyValuePair.Value.Symbol_Native);
    		Console.WriteLine("\tDecimal Digits: {0}", keyValuePair.Value.Decimal_Digits);
    		Console.WriteLine("\tCode: {0}", keyValuePair.Value.Code);
    		Console.WriteLine();
    	}
    }

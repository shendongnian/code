	readonly Regex TernaryParserRegex = new Regex(@"^=\?(?<ifNull>(?:\\(\\\\)*:|[^:])*)(?<!\\):(?<ifNotNull>(?:\\(\\\\)*:|[^:])*)$");		
	string[] ParseTernaryString (string ternaryStatement)
	{
		var results = TernaryParserRegex.Match(ternaryStatement);
		if (results.Success) 
		{
			string[] returnVal = {results.Groups["ifNull"].Value, results.Groups["ifNotNull"].Value};
			return returnVal;
		}
		else
		{
			throw new Exception("Invalid Ternary Statement");
		}
	}
	string Parse(string value, string ternaryStatement) 
	{
		var returnValues = ParseTernaryString(ternaryStatement);
		return string.IsNullOrEmpty(value) ? returnValues[0]: returnValues[1];
	}
	
	void Main()
	{
		Console.WriteLine(Parse("", "=?treat as null:not expected"));
		Console.WriteLine(Parse("hello", "=?not expected:this value's not null"));
	}

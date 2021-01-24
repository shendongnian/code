	private static readonly Regex TernaryParserRegex = new Regex(
        @"^=\?(?<ifNull>(?:\\(\\\\)*:|[^:])*)(?<!\\):(?<ifNotNull>(?:\\(\\\\)*:|[^:])*)$"
        /* , RegexOptions.Compiled //include this line for performance if appropriate */
    );		
	private string[] ParseTernaryString (string ternaryStatement)
	{
		var results = TernaryParserRegex.Match(ternaryStatement);
		if (results.Success) 
		{
			string[] returnVal = {
                results.Groups["ifNull"].Value
                , 
                results.Groups["ifNotNull"].Value
            };
			return returnVal;
		}
		else
		{
			throw new Exception("Invalid Ternary Statement"); //use an appropriate exception type here; or have the function return `{null,null}` / some other default as appropriate 
		}
	}
	public string Parse(string value, string ternaryStatement) 
	{
		var returnValues = ParseTernaryString(ternaryStatement);
		return string.IsNullOrEmpty(value) ? returnValues[0]: returnValues[1];
	}
	
    //Example Usage:
	Console.WriteLine(Parse("", "=?treat as null:not expected"));
	Console.WriteLine(Parse("hello", "=?not expected:this value's not null"));

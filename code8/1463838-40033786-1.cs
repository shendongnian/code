    public static string UnescapeIt(string str)
    {
    	var regex = new Regex(@"(?<!\\)(?:\\u[0-9a-fA-F]{4}|\\U[0-9a-fA-F]{8})", RegexOptions.Compiled);
    	return regex.Replace(str,
    		m =>
    		{
    			if (m.Value.IndexOf("\\U", StringComparison.Ordinal) > -1)
    				return char.ConvertFromUtf32(int.Parse(m.Value.Replace("\\U", ""), NumberStyles.HexNumber));
    			return Regex.Unescape(m.Value);
    		});
    }

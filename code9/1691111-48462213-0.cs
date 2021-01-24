    public static class AuthenticateParser
	{
		public static IDictionary<string, string> Parse(string value)
		{
			//https://stackoverflow.com/questions/45516717/extracting-and-parsing-the-www-authenticate-header-from-httpresponsemessage-in/45516809#45516809
			string[] commaSplit = value.Split(", ".ToCharArray());
		
			return commaSplit
				.ToDictionary(GetKey, GetValue);
		}
		
		private static string GetKey(string pair)
		{
			int equalPos = pair.IndexOf("=");
			
			if (equalPos < 1)
				throw new FormatException("No '=' found.");
				
			return  pair.Substring(0, equalPos);
		}
		
		private static string GetValue(string pair)
		{
			int equalPos = pair.IndexOf("=");
			
			if (equalPos < 1)
				throw new FormatException("No '=' found.");
				
			string value = pair.Substring(equalPos + 1).Trim();
			
			//Trim quotes
			if (value.StartsWith("\"") && value.EndsWith("\""))
			{
				value = value.Substring(1, value.Length - 2);
			}
			
			return value;
		}
	}

	public static class LanguageExtensions
	{
		
		// Define case insentive dictionary
		public static Dictionary<string, string> Rules = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
		{
			// List rules here
			{ "ys", "y"},
		};
		
		public static string ApplyRules(this string input)
		{
			string suffix;
			if (input != null && input.Length > 2 && Rules.TryGetValue(input.Substring(input.Length - 2, 2), out suffix))
				return input.Remove(input.Length - 2) + suffix;
			else
				return input;
		}
	}

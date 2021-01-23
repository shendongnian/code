	public static string[] ExtractStringBetweenDelimiters(string sample, string open, string close)
	{
		int openIndex = sample.IndexOf(open);
		int closeIndex = sample.LastIndexOf(close);
		
		var top = sample.Substring(0, openIndex);
		var bottom = sample.Substring(openIndex + 1, closeIndex - openIndex - 1);
						
		return new [] { top, bottom };			
	}

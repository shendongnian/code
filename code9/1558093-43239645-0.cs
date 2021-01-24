    public static class HeaderExtensions
    {
    	public static void SetMultiValuedCookie(
            this IHeaderDictionary headers,
            string key,
            params KeyValuePair<string, string>[] values)
    	{
    		if (string.IsNullOrWhiteSpace(key))
    		{
    			throw new ArgumentNullException(nameof(key));
    		}
    
    		if (values == null)
    		{
    			throw new ArgumentNullException(nameof(values));
    		}
    
    		if (0 >= values.Length)
    		{
    			throw new ArgumentOutOfRangeException(nameof(values));
    		}
    
    		var value = string.Join("&", values.Select(v => $"{Uri.EscapeDataString(v.Key)}={Uri.EscapeDataString(v.Value)}"));
    
    		headers.AppendValues("Set-Cookie", Uri.EscapeDataString(key) + "=" + value + "; path=/");
    	}
    }

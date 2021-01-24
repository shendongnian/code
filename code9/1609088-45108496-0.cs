    public static string Base64UrlDecode(string input)
    {
    	if (string.IsNullOrWhiteSpace(input))
    		return "<strong>Message body was not returned from Google</strong>";
    
    	string InputStr = input.Replace("-", "+").Replace("_", "/");
    	return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(InputStr));
    
    }

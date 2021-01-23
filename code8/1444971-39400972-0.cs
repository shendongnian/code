    public static class StringTemplatingExtensions
    {
    	public static string ParseTemplate(this string template, IDictionary<string, object> valueMap)
    	{
    		foreach(var pair in valueMap)
    		{
    			template = template.Replace($"<%{pair.Key}%>", pair.Value.ToString());
    		}
    		
    		return template;
    	}
    }

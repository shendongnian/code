    public string ReplaceWords(string input, Dictionary<string,string> dictionary)
    {
    	var result = Regex.Replace(input, @"\w*", (match) =>
      {
    	  if (dictionary.TryGetValue(match.Value, out var replacement))
    	  {
    		  return replacement;
    	  }
    	  return match.Value;
      });
      return result;
    }

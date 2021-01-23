    public static string ReplaceMultiple(
              string template, 
              IEnumerable<KeyValuePair<string, string>> replaceParameters)
    {
       var result = template;
       foreach(var replace in replaceParameters)
       {
          var templateSplit = Regex.Split(result, 
                                        replace.Key, 
                                        RegexOptions.IgnoreCase);
          result = string.Join(replace.Value, templateSplit);
       }
       return result;
    }

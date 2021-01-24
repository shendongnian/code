    public static string ToKebabCase(string value)
    {
       if (string.IsNullOrEmpty(value))
          return value;
    
       return Regex.Replace(value, @"(?<!/)([A-Z])(?![^\{\}]*\})", "-$1").Trim().ToLower();
    }

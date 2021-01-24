    public static string ToKebabCase(this string value)
    {
       if (string.IsNullOrEmpty(value))
          return value;
    
       var list = value.Split('/');
       list[1] = Regex.Replace(list[1], "([A-Z])", "-$1").Trim();
    
       return string.Join("/", list).Trim().ToLower();
    }

    private static string ToDancing(string value) {
      if (string.IsNullOrEmpty(value))
        return value;
      bool upper = false;
      StringBuilder sb = new StringBuilder(value.Length);
      foreach (var c in value) 
        if (char.IsLetter(c)) 
          sb.Append((upper = !upper) ? char.ToUpper(c) : char.ToLower(c));
        else
          sb.Append(c);
      return sb.ToString();
    }

    public static List<string> SplitPreserveSeparators(string source, char[] delimiters) {
      if (null == source)
        throw new ArgumentNullException("source") 
      else if (delimiters == null)
        throw new ArgumentNullException("delimiters") 
      int start = 0;
      int index = -1;
      List<string> items = new List<string>();
      while ((index = source.IndexOfAny(delimiters, start)) >= 0) {
        string value = source.Substring(start, index - start);
        if (!string.IsNullOrEmpty(value))
          items.Add(value);
        items.Add(source.Substring(index, 1));
        start = index + 1;
      }
      if (start < source.Length)
        items.Add(source.Substring(start));
      return items;
    }

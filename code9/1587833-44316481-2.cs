    public static class StringExtensions {
      public static string ToLength(this string source, int length) {
        if (length < 0)
          throw new ArgumentOutOfRangeException("length");
        else if (length == 0)
          return "";
        else if (string.IsNullOrEmpty(source))
          return new string(' ', length);
        else if (source.Length < length)
          return source.PadRight(length);
        else
          return source.Substring(0, length); 
      }   
    }

    public class StringExtensions {
      public static bool ContainsLike(this string source, string like) {
        if (string.IsNullOrEmpty(source))
          return false;
        else if (string.IsNullOrEmpty(like))
          return false;  
        return Regex.IsMatch(
          source,
          "^" + Regex.Escape(like).Replace("_", ".").Replace("%", ".*") + "$");
      }
    }

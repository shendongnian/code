    public class StringExtensions {
      public static bool ContainsLike(this string source, string like) {
        if (string.IsNullOrEmpty(source))
          return false; // or throw exception if source == null
        else if (string.IsNullOrEmpty(like))
          return false; // or throw exception if like == null 
        return Regex.IsMatch(
          source,
          "^" + Regex.Escape(like).Replace("_", ".").Replace("%", ".*") + "$");
      }
    }

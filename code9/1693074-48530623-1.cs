    internal static class Extensions 
    {
      public static int AsInt(this string s, int default = 0)
      {
        int result;
        if (s == null)
          return default;
        else if (int.TryParse(s, out result))
          return result;
        else
          return default;
      }
    }

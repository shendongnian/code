    internal static class Extensions 
    {
      public static int? AsInt(this string s)
      {
        int result;
        if (s == null)
          return null;
        else if (int.TryParse(s, out result))
          return result;
        else
          return null;
      }
    }

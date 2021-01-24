    // must be a top lvl class to enable declaring extension method
    public static class StringExt
    {
        public static bool IsSet(this string s)
          => s != null && s.Trim().Length > 0;
    }

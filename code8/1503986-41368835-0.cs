    public static class CustomExtensions
    {
         public static string TrimIfNotNull(this string value)
         {
             if (value != null)
             {
                 value = value.Trim();
             }
             return value;
         }
    }

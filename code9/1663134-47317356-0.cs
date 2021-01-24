    static class Helper
    {
           public static string DefaultIfNullOrEmpty(this string str) 
           {
                return String.IsNullOrEmpty(str) ? "N/A" : str;
           }
    }

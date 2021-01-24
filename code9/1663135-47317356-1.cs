    static class Helper
    {
           public static string NonApplicableIfNullOrEmpty(this string str) 
           {
                return String.IsNullOrEmpty(str) ? "N/A" : str;
           }
    }

    static class Helper
    {
           public static string NotApplicableIfNullOrEmpty(this string str) 
           {
                  return String.IsNullOrEmpty(str) ? "N/A" : str;
           }
    }

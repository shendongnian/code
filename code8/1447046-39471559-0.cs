    public static class MyExtensions
    {
        public static string MakeToOneInstance(this String str, string toReplace)
        {
            return Regex.Replace(str, string.Format("(?:{0}){1}", toReplace, "{2,}"), toReplace);
        }
    } 

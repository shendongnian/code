    public static class MyExtensions
    {
        public static string MakeToOneInstance(this String str, string toReplace)
        {
            return Regex.Replace(str, string.Format("\\b(?:{0}){1}\\b", Regex.Escape(toReplace), "{2,}"), toReplace);
        }
    }   

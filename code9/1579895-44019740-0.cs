    public static class ExtensionMethods
    {
        public static string IfNotEquals(this string s1, s2, string label)
        {
            if (s1 != s2)
            {
                return label + s1;
            }
    
            return null;
        }
    }

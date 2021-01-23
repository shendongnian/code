    public static class Helper
    {
        public static string RemoveNullCharacter(this string str)
        {
            return str.Replace("\0", "");
        }
    }

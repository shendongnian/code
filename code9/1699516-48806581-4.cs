    public static class SplitExtension
    {
        public static string LastNItems(this string str, int nItem, char separator = '.')
        {
            return string.Join(separator.ToString(), str.Split(separator).Reverse().Take(nItem).Reverse());
        }
        public static string[] LastNItems(this string[] strArray, int nItem)
        {
            return strArray.Reverse().Take(nItem).Reverse().ToArray();
        }
    }

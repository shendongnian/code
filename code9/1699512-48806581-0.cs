    public static class CommonExtension
    {
        public static string LastNItems(this string str, int nItem, char separator = '.')
        {
            return string.Join(separator.ToString(), str.Split(separator).Reverse().Take(nItem).Reverse());
        }
    }

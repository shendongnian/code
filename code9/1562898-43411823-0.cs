    static class ExtMethods
    {
        public static IEnumerable<int> IndexesOf(this string str, char c)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                yield return i;
            }
        }
    }

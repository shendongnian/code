    public static class StringExtensions
    {
        public static bool Contains(this string statement, string word, StringComparison stringComparison)
        {
            return statement?.IndexOf(word, stringComparison) >= 0;
        }
    }
    string sql = "SELECT * FROM SomeTable WHERE Column1 LIKE '%reyan%'";
    bool contains = sql.Contains("where", StringComparison.OrdinalIgnoreCase); // contains = true

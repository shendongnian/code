    public static string SStr(string s)
    {
        return string.IsNullOrEmpty(s) ? "NULL" : "N'" + s.Replace("'","''") + "'";
    }
    private static void makeSQLThread(List<Product> products, List<string> sqlList)
    {
        foreach (var item in products)
        {
            var formatSQl = $"UPDATE products SET ColorId = {item.ColorId}, Description = {SStr(item.Description)}, LongDescription = {item.LongDescription}, isAvailable = {item.isAvailable ? 1 : 0} WHERE Id = {item.Id};";
            Console.WriteLine(formatSQl);
            sqlList.Add(formatSQl);
        }
    }

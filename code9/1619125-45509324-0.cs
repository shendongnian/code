    public static IEnumerable<string> GetFiles(string path, string searchPatternExpression = "", SearchOption searchOption =    SearchOption.AllDirectories)
    {
        Regex reSearchPattern = new Regex(searchPatternExpression);
        return Directory.EnumerateFiles(path, "*", searchOption).Where(file => reSearchPattern.IsMatch(System.IO.Path.GetExtension(file)));
     }

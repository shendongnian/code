	private static Regex _regex = new Regex(@"(?<=^|[-(+*/])-(?<value>\d+|\((?:[^\(\)]|(?<open>\()|(?<-open>\)))+?(?(open)(?!))\))", RegexOptions.Compiled);
 
	private static string RemoveUnaryOperators(string input)
    {
        var result = Regex.Replace(input ?? string.Empty, @"\s+", string.Empty);
        string tmp;
        do
        {
            tmp = result;
            result = _regex.Replace(result, @"(0-${value})");
        }
        while (result != tmp);
 
       return result;
    }

    public static string GetName<TSource>(Expression<Func<TSource, object>> lambda)
    {
        var code = lambda.Body.ToString();
        var match = Regex.Match(code, @"^\w+\.((?:\w+\.)*\w+)$");
        if (!match.Success)
            throw new ArgumentException("Unexpected expression tree");
        return match.Groups[1].Value;
    }

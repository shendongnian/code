    private static string ParseKeys(IEnumerable<KeyValuePair<string, StringValues>> values)
    {
        var sb = new StringBuilder();
        foreach (var value in values)
        {
            sb.AppendLine(value.Key + " = " + string.Join(", ", value.Value));
    	}
    	return sb.ToString();
    }

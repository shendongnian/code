    private static string ParseKeys(IEnumerable<KeyValuePair<string, string[]>> dict)
    {
        var sb = new StringBuilder();
        foreach (var keyValuePair in dict)
        {
            sb.AppendLine(keyValuePair.Key + " = " + String.Join(", ", keyValuePair.Value));
        }
        return sb.ToString();
    }

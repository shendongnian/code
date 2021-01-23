    var valueRegex = new Regex(".*secret.*", RegexOptions.IgnoreCase);
    var query2 = root.DescendantsAndSelf()
        .OfType<JValue>()
        .Where(v => v.Type == JTokenType.String && valueRegex.IsMatch((string)v));
    query2.RemoveFromLowestPossibleParents();
    var finalJsonString = root.ToString();

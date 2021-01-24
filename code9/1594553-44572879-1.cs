    public static bool HasProperty(this HtmlNode node, string property, params string[] valueArray)
    {
        var propertyValue = node.GetAttributeValue(property, "");
        var propertyValues = propertyValue.Split(' ');
        return valueArray.All(c => propertyValues.Contains(c));
    }
    
    public static string StopAt(this string input, char stopAt)
    {
        int x = input.IndexOf(stopAt);
        return input.Substring(0, x);
    }

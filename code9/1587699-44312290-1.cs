        var xDocument = XDocument.Parse("<root><a>hello</a> <b>hello world</b> <c>I like apple</c></root>");
        var dictionary1 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) { { "hello", "Hi" }, { "world", "people" }, { "apple", "fruit" } };
        string pattern = @"\w+";
        Regex match = new Regex(pattern, RegexOptions.IgnoreCase);
        var xElements = xDocument.Root.Descendants()
                          .Where(x => dictionary1.Keys.Any(s => x.Value.Contains(s)));
        foreach (var xElement in xElements)
        {
            var updated = match.Replace(xElement.Value, 
                               replace => {
                                    return dictionary1.ContainsKey(replace.Value) 
                                       ? dictionary1[replace.Value] : replace.Value; });
            xElement.Value = updated;
        }
        string output = xDocument.ToString();

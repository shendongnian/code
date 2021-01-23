    var toReplace = new Dictionary<string, string>()
    {
        {"GetName", "Value1" },
        {"GetID", "Value2" },
        {"GetNumber", "Value3" },
    };
    string input = @"Read text1 <%GetName%> Read text2 <%GetID%> Read tex3 <%GetNumber%> and more";
    var output = Regex.Replace(input, @"<%(.+?)%>", m => toReplace[m.Groups[1].Value]);

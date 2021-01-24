    var parsedJson = JToken.Parse(json);
    var nodes = parsedJson.SelectTokens("$..*");
    foreach (var node in nodes.OfType<JObject>())
    {
        var pathValue = node.Property("F")?.Value?.Value<string>();
        if (string.IsNullOrWhiteSpace(pathValue))
        {
            continue;
        }
    
        var depth = pathValue.Split(new[] { '/' }, StringSplitOptions.None).Length;
        node.Add("depth", depth - 1);
    }
    var modifiedJson = parsedJson.ToString();

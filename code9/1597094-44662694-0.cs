    using Newtonsoft.Json.Linq;
    ...
    string json = node.GetProperty("postImage").Value;
    var parsedJson = JObject.Parse(json);
    var srcValue = parsedJson.Properties().FirstOrDefault(item => item.Name == "src")?.Value;

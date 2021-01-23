    JObject jo = JObject.Parse(File.ReadAllText(file.json));
    foreach (var prop in jo.SelectTokens("$..Component.Content")
        .Children().OfType<JProperty>())
    {
        prop.Value = "New Title";
    }
    string jsonText = JsonConvert.SerializeObject(jo, Formatting.Indented);

    private const string ContextPropertyJson = "\"@context\":\"http://schema.org\",";
    public override string ToString() => RemoveAllButFirstContext(
        JsonConvert.SerializeObject(this, new JsonSerializerSettings));
    private static string RemoveAllButFirstContext(string json)
    {
        var stringBuilder = new StringBuilder(json);
        var startIndex = ContextPropertyJson.Length + 1;
        stringBuilder.Replace(
            ContextPropertyJson, 
            string.Empty, 
            startIndex, 
            stringBuilder.Length - startIndex - 1);
        return stringBuilder.ToString();
    }

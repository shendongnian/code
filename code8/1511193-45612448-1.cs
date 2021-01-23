    var jObject = JObject.Parse(body);
    
    JToken token;
    if (jObject.TryGetValue(
        Constants.FieldName,
        StringComparison.InvariantCultureIgnoreCase,
        out token))
    {
        var jProperty = token.Parent as JProperty;
        if (jProperty != null)
        {
            jProperty.Value = "removed";
        }
    
        body = jObject.ToString(Formatting.Indented);
    }

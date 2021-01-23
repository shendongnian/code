    public Dictionary<string, object> ParseJson(string json) {
    
        var obj = JObject.Parse(json);
    
        var dict = new Dictionary<string, object>();
    
        foreach (var property in obj) {
            var name = property.Key;
            var value = property.Value;
        
            if (value is JArray) {
                dict.Add(name, value.ToArray());
            }
            else if (value is JValue) {
                dict.Add(name, value.ToString());
            }
            else {
                throw new NotSupportedException("Invalid JSON token type.");
            }
        }
    
        return dict;    
    }

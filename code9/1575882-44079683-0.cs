    public override object ReadJson(JsonReader reader, Type objectType, 
                                    object existingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);
        object targetObj = Activator.CreateInstance(objectType);
        foreach (PropertyInfo prop in objectType.GetProperties()) {
            string jsonPath = prop.Name;
            JToken token = jo.SelectToken(jsonPath);
            if (jsonPath.Equals("OptionalDataSet1")) {
                var innerItems = jo.SelectToken("Wrapper[0]").SelectToken(jsonPath).Values();
                var finalItem = new JObject();
                foreach (var item in innerItems) {
                    var tempItem = new JObject(item);
                    finalItem.Merge(tempItem);
                }
            } else {
                token = jo.SelectToken(jsonPath).First();
            }
            if (token != null && token.Type != JTokenType.Null) {
                object value = token.ToObject(prop.PropertyType, serializer);
                prop.SetValue(targetObj, value, null);
            }
        }
        return targetObj;
    }

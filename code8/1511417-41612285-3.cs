    public IEnumerable<MeItem> DeserializeListFromJson(string jsonArray)
    {
        return JsonConverter.DeserializeObject<List<JObject>>(jsonArray).Select( obj => DeserializeFromJson(obj) );
    }
    
    public MeItem DeserializeFromJson(string jsonString)
    {
        return JsonConvert.DeserializeObject<MeItem>(jsonString);
    }

    public List<DataItem> DeserializeListFromJson(string jsonArray)
    {
        List<DataItem> result = new List<DataItem>();
        foreach(JObject obj in JsonConverter.DeserializeObject<List<JObject>>(jsonArray))
        {
            result.Add(DeserializeFromJson(obj.ToString());
        }
        return result;
    }

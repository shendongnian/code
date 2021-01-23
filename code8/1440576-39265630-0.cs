    public static Dictionary<string,object> BinderModel(string model)
    {
        Dictionary<string,JToken> result = new Dictionary<string,object>();
        JObject jObject = JObject.Parse(model);
        foreach (JProperty x in (JToken)jObject )
        {
             result.Add(x.Name,x.Value);
        }
        return result;
    }

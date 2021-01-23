    private Dictionary<string, string> GenerateQueryParameters(object queryParametersObject)
    {
        var res = new Dictionary<string, string>();
        var props = queryParametersObject.GetType().GetProperties();
        foreach (var prop in props)
        {
            res[prop.Name] = prop.GetValue(queryParametersObject).ToString();
        }
        return res;
    }

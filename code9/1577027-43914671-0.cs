    private bool CompareTwoObjects<T>(T one, T two)
    {
        var json1 = JObject.FromObject(one);
        var json2 = JObject.FromObject(two);
        foreach (JProperty prop1 in json1.Properties())
        {
            var prop2 = json2.Properties().First(p => p.Name == prop1.Name);
            if (prop1.Value != prop2.Value)
            {
                return false;
            }
        }
        return true;
    }

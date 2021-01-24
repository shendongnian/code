    JArray jsonArray = JsonConvert.DeserializeObject<JArray>(json);
    foreach (JObject item in jsonArray.Children<JObject>())
    {
        foreach (JProperty element in item.Properties())
        {
            Console.WriteLine(string.Format("Key: {0}", element.Name));
            Console.WriteLine(string.Format("Value: {0}", element.Value.ToString()));
        }
    }

    var result = JsonConvert.DeserializeObject<JObject>(json);
    var data = new TestData
    {
        Name = (string)result["name"],
        Data = result["data"]
            .Select(t => new Tuple<DateTime, double>(DateTime.Parse((string)t[0]), (double)t[1]))
            .ToList()
    };

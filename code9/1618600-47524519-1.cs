    var settings = new JsonSerializerSettings();
	settings.Converters.Add(new TupleConverter());
    
    var list = new List<(DateTime, double)>
    {
        (DateTime.Now, 7.5)
    };
    var json = JsonConvert.SerializeObject(list, settings);
    var result = JsonConvert.DeserializeObject(json, list.GetType(), settings);

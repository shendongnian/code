    var myObject = new MyModelClass("blablabla", "<>@%#^^@!%");
    var settings = new JsonSerializerSettings
    {
        ContractResolver = new CustomResolver(),
        Formatting = Formatting.Indented
    };
    string json = JsonConvert.SerializeObject(myObject, settings);

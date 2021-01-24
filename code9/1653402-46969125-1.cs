    var obj = new object();
    //Add prop to instance
    int propVal = 0; 
    var propManager = new DynamicPropertyManager<object>(obj);
    propManager.Properties.Add(
        DynamicPropertyManager<object>.CreateProperty<object, int>(
        "Value", t => propVal, (t, y) => propVal = y, null));
    propVal = 3;
    var settings = new JsonSerializerSettings
    {
        ContractResolver = new DynamicPropertyContractResolver<object>(propManager, obj),
    };
    //Serialize object here
    var json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
    Console.WriteLine(json);

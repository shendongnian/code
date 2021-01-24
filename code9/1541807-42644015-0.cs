    using Newtonsoft.Json;
    
    // ...
    
    // Set
    var jsonData = JsonConvert.SerializeObject(tModel);
    _distributedCache.SetString("model", jsonData);
    
    // Get
    var jsonData = _distributedCache.GetString("model");
    var tModel = JsonConvert.DeserializeObject<TestModel>(jsonData);

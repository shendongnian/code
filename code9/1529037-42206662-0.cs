    using Newtonsoft.Json; 
    private static readonly JsonSerializerSettings StrictJsonSettings = new JsonSerializerSettings {
        MissingMemberHandling = MissingMemberHandling.Error
    };
    Test test = JsonConvert.DeserializeObject<Test>(MyJsonString, StrictJsonSettings);
    var jsonId = test[1].Id;

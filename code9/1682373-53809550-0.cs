    var settings = new JsonSerializerSettings
    {
        Converters = { new StringEnumConverter(typeof(SnakeCaseNamingStrategy)) },
    };
    var json = JsonConvert.SerializeObject(MyEnum.ValueOne, settings);
    Assert.IsTrue(json == "\"value_one\""); // Passes successfully

    var errors = new List<string>();
    var json2 = "{\"myint\":3554860000,\"Mybool\":false}";
    using (var reader = new FixedJsonTextReader(new StringReader(json2)))
    {
        var settings = new JsonSerializerSettings
        {
            Error = delegate(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
            {
                Debug.WriteLine(args.ErrorContext.Error.Message);
                errors.Add(args.ErrorContext.Error.Message);
                args.ErrorContext.Handled = true;
            }
        };
        var i = JsonSerializer.CreateDefault(settings).Deserialize<MyClass>(reader);
    }
    Assert.IsTrue(errors.Count <= 1); // Passes

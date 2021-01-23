    var factory = new Factory();
    var test = new Foo(factory)
    {
        Bars = { new Bar(factory) },
    };
    var json = DataContractJsonSerializerHelper.SerializeJson(test);
    Debug.WriteLine(JToken.Parse(json));
    Foo test2;
    using (HasFactoryBase.SetDeserializedFactory(factory))
    {
        test2 = DataContractJsonSerializerHelper.DeserializeJson<Foo>(json);
    }
    if (test2.Factory != test.Factory)
        throw new InvalidOperationException();

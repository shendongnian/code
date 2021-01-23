    var factory = new Factory();
    var test = new Foo(factory)
    {
        Bars = { new Bar(factory) },
    };
    var serializer = new DataContractJsonSerializer(test.GetType());
    byte [] json;
    using (var stream = new MemoryStream())
    {
        serializer.WriteObject(stream, test);
        json = stream.ToArray();
    }
    Foo test2;
    using (HasFactoryBase.SetDeserializedFactory(factory))
    using (var stream = new MemoryStream(json))
    {
        test2 = (Foo)serializer.ReadObject(stream);
    }
    if (test2.Factory != test.Factory)
        throw new InvalidOperationException();

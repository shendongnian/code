    var factory = new Factory();
    var test = new Foo(factory)
    {
        Bars = { new Bar(factory) },
    };
    var surrogate = new FactorySurrogateSelector(factory);
    var serializer = new DataContractJsonSerializer(test.GetType(), Enumerable.Empty<Type>(), int.MaxValue, false, surrogate, false);
    var json = DataContractJsonSerializerHelper.SerializeJson(test, serializer);
    var test2 = DataContractJsonSerializerHelper.DeserializeJson<Foo>(json, serializer);
    if (test2.Factory != test.Factory)
        throw new InvalidOperationException();

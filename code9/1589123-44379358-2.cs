    var settings = new JsonSerializerSettings
    {
        Converters = { new ServicePropertyConverter() },
        //NullValueHandling.Ignore cannot be used because ServicePropertyConverter.ReadJson()
        //will not get called during reading to allocate an empty ServiceProperty<T>.
        //NullValueHandling = NullValueHandling.Ignore,
        //Instead DefaultValueHandling.IgnoreAndPopulate must be used to skip serialization
        //of a null ServiceProperty<T> when serializing but force ServicePropertyConverter.ReadJson()
        //to be called when deserializing.
        DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
    };

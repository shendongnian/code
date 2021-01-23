    var baseObject = new BaseClass { Name = "BaseObject" };
    using (var stream = new MemoryStream())
    {
        ProtoBuf.Serializer.Serialize(stream, baseObject);
        Debug.WriteLine(stream.Length);
        stream.Seek(0, SeekOrigin.Begin);
        // throws invalid cast exception : 
        var derivedObjectOut = ProtoBuf.Serializer.Deserialize<DerivedClass>(stream);
    }

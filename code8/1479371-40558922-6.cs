    var baseObject = new BaseClass { NameInBaseClass = "BaseObject" };
    using (var stream = new MemoryStream())
    {
        ProtoBuf.Serializer.Serialize(stream, baseObject);
        Debug.WriteLine(stream.Length);
        stream.Seek(0, SeekOrigin.Begin);
        var derivedObjectOut = ProtobufExtensions.DeserializeOrMerge<DerivedClass>(stream);
    }

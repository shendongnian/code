    public static void OriginalTest()
    {
        var derivedObject = new DerivedClass { Name = "DerivedObject", Index = 1 };
        using (var stream = new MemoryStream())
        {
            ProtoBuf.Serializer.Serialize(stream, derivedObject);
            Debug.WriteLine(stream.Length);
            stream.Seek(0, SeekOrigin.Begin);
            // throws invalid cast exception : 
            var derivedObjectOut = ProtoBuf.Serializer.Deserialize<DerivedClass>(stream);
        }
    }

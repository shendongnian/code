    Model obj = new Model();
    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsondoc)))
    {
        DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Model));
        obj = (Model)deserializer.ReadObject(ms);
    }

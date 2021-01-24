    var deserializer = new DataContractJsonSerializer(typeof(tubeStatusRootObject[]));
    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(result)))
    {
        var data = (tubeStatusRootObject[])deserializer.ReadObject(ms);
    }

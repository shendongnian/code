    var target = new MyStruct(2);
    // with Data Contract serializer
    using (var ms = new MemoryStream()) {
        var s = new DataContractSerializer(typeof(MyStruct));
        s.WriteObject(ms, target);
        ms.Position = 0;
        var back = (MyStruct) s.ReadObject(ms);
        Debug.Assert(target.Equals(back));
    }
    
    // with Json.NET
    var json = JsonConvert.SerializeObject(target);
    var jsonBack = JsonConvert.DeserializeObject<MyStruct>(json);
    Debug.Assert(target.Equals(jsonBack));
    // with binary formatter
    using (var ms = new MemoryStream()) {
        var formatter = new BinaryFormatter();
        formatter.Serialize(ms, target);
        ms.Position = 0;
        var back = (MyStruct) formatter.Deserialize(ms);
        Debug.Assert(target.Equals(back));
    }

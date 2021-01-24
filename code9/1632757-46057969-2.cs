    List<IBase> loList = new List<IBase>();
    loList.Add(new Base() { Name = "Base" });
    loList.Add(new Derived1() { Name = "Derived1", Value = 3 });
    loList.Add(new Derived2() { Name = "Derived2", Value = true });
    
    KnownTypesBinder loKnownTypesBinder = new KnownTypesBinder()
    {
        KnownTypes = new List<Type> { typeof(Base), typeof(Derived1), typeof(Derived2) }
    };
    
    IEnumerable<IBase> reportingData = loList.AsEnumerable();
    JsonSerializerSettings loJsonSerializerSettings = new JsonSerializerSettings()
    {
        TypeNameHandling = TypeNameHandling.Objects,
        SerializationBinder = loKnownTypesBinder
    };
    
    string lsOut = JsonConvert.SerializeObject(reportingData, loJsonSerializerSettings);
    reportingData = JsonConvert.DeserializeObject<IEnumerable<IBase>>(lsOut, loJsonSerializerSettings);

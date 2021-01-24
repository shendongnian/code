    List<IModel> sourceList = new List<IModel> {new Model("A", 1), new Model("B", 2)};
    AutoMapper.Mapper.Initialize(a => a.CreateMap<IModel, Model>());
    List<Model> targetList = AutoMapper.Mapper.Map<List<IModel>, List<Model>>(sourceList);
    
    AutoMapper.Mapper.Initialize(a =>
    {
        a.CreateMap<Model, Model>();
        a.CreateMap<Model, IModel>().ConstructUsing(Mapper.Map<Model, Model>);
    });
    
    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Model>), new[] { typeof(Model) });
    using (FileStream writer = File.Create(@"c:\temp\modello.json"))
    {
        jsonSerializer.WriteObject(writer, targetList);
    }
    
    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Model>));
    MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(File.ReadAllText(@"c:\temp\modello.json")));
    List<Model> targetListFromFile = (List<Model>)js.ReadObject(ms);
    List<IModel> sourceListFromFile = AutoMapper.Mapper.Map<List<Model>, List<IModel>>(targetListFromFile);

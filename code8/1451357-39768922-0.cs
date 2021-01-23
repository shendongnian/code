    var list = new List<B> { new B { prop1 = "1", prop2 = "2", prop3 = "3", prop4 = "4" } };
    Mapper.Initialize(i => i.CreateMap<B, A>());
    using (var stream = new FileStream(@"output.xml", FileMode.Create))
    {
        var serializer = new DataContractSerializer(typeof(List<A>));
        serializer.WriteObject(stream, list.Select(i => Mapper.Map<A>(i)).ToList());
    }

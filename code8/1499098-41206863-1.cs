        NeedClass c = new NeedClass { Id = 1, Name = "Name" };
        OtherClass oc = Mapper.Map<NeedClass, OtherClass>(c, (input, output) =>
        {
            output.Id = input.Id;
            output.Name = input.Name;
        });

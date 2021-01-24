	Mapper.Initialize(cfg => cfg.CreateMap<A, B>().ReverseMap());
	var objA = new A
	{
		Prop = new List<AClass>
		{
			new AClass { Name = "Magneto" },
			new AClass { Name = "Wolverine" }
		}
	};
	var objB = Mapper.Map<B>(objA);
	Console.WriteLine(objB.Prop[0].Name);
	Console.WriteLine(objB.Prop[1].Name);

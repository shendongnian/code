	var types = Assembly.GetExecutingAssembly().ExportedTypes
               .Where(x=>x.GetInterfaces().Contains(typeof(ISetIdGenerator)));
	foreach (var type in types)
	{
		var classMap = new BsonClassMap(type);
		classMap.AutoMap();
		classMap.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
		BsonClassMap.RegisterClassMap(classMap);
	}

	using (var s = File.OpenText(@"c:\bigdata.json"))
	using (var baseReader = new JsonTextReader(s))
	using (var reader = new JSchemaValidatingReader(baseReader))
	{
		reader.Schema = schema;
		reader.ValidationEventHandler += (sender, args) => { Console.WriteLine(args.Message); };
		root = JsonSerializer.CreateDefault().Deserialize<RootObject>(reader);
	}

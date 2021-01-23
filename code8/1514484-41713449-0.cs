	var source = @"Functional Loc.    Description SupFunctLoc.
    70003  ABC AS002
    70C2   ABC 70003
    70C2.01    ABC 70C2
    70C2.01.02 ABC 70C2.01
    70C2.01.02.10  ABC 70C2.01.02
    70C2.01.02.10-BG010    ABC 70C2.01.02.10";
	var lines =
		source
			.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
			.Select(x => x.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
	var results =
		lines
			.Skip(1)
			.Select(x => new Input()
			{
				FunctionalLocation = x[0],
				Description = x[1],
				SuppFunctionalLocation = x[2],
			});
	var lookup = results.ToLookup(x => x.SuppFunctionalLocation);
	Func<string, List<Input>> build = null;
	build = SuppFunctionalLocation =>
		lookup[SuppFunctionalLocation]
			.Select(x => new Input()
			{
				FunctionalLocation = x.FunctionalLocation,
				Description = x.Description,
				SuppFunctionalLocation = x.SuppFunctionalLocation,
				Children = build(x.FunctionalLocation),
			})
			.ToList();
			
	List<Input> tree = build("AS002");

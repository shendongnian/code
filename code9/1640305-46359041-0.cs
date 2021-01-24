	var dictActions = new Dictionary<Action, bool>();
	dictActions.Add(Action.IsFbClicked, true);
	dictActions.Add(Action.IsTwitterClicked, false);
	var config = new MapperConfiguration(cfg =>
	{
		cfg.CreateMap<KeyValuePair<Action, bool>, WebAction>()
			.ForMember(webAction => webAction.IsFbClicked, conf => conf.MapFrom(kvp => kvp.Key == Action.IsFbClicked && kvp.Value))
			.ForMember(webAction => webAction.IsTwitterClicked, conf => conf.MapFrom(kvp => kvp.Key == Action.IsTwitterClicked && kvp.Value));
	});
	var mapper = new Mapper(config);
	var items = mapper.DefaultContext.Mapper.Map<List<WebAction>>(dictActions);
	foreach (var item in items)
	{
		Console.WriteLine("Entry: " + "IsFb = " + item.IsFbClicked + " IsTwitter = " + item.IsTwitterClicked);
	}

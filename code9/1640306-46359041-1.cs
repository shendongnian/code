	var dictActions = new Dictionary<Action, bool>();
	dictActions.Add(Action.IsFbClicked, true);
	dictActions.Add(Action.IsTwitterClicked, false);
	
	var config = new MapperConfiguration(cfg =>
	{
		cfg.CreateMap<Dictionary<Action, bool>, WebAction>()
			.ForMember(webAction => webAction.IsFbClicked, conf => conf.MapFrom(dict => GetValue(Action.IsFbClicked, dict)))
			.ForMember(webAction => webAction.IsTwitterClicked, conf => conf.MapFrom(dict => GetValue(Action.IsTwitterClicked, dict)));
	});
	
	var mapper = new Mapper(config);
	var item = mapper.DefaultContext.Mapper.Map<WebAction>(dictActions);
	
	Console.WriteLine("Entry: " + "IsFb = " + item.IsFbClicked + " IsTwitter = " + item.IsTwitterClicked);

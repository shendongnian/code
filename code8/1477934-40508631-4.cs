    var container = new Container();
	container.Sonos = new List<Dictionary<string, List<Cfg>>>
	{
		new Dictionary<string, List<Cfg>>
		{
			{ "192.168.10.214", new List<Cfg> { new Cfg { Volume = "5" } } }
		}
	};
  
    var json = JsonConvert.SerializeObject(container);

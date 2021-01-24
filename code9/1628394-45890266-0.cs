    ...
    new ChannelConf {
    Name = "Abc"
    Headers = GetNewDictionary(addNew)
    }
    ...
	private Dictionary<string, string> GetNewDictionary(bool addNew)
	{
		Dictionary<string, string> output = new Dictionary<string, string> { [Constants.Key1] = Id };
		if (addNew) { output.Add(Constants.Key2, Port); }
		return output;
	}

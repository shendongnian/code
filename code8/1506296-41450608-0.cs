	public List<Publisher> Publishers
	{
	    get { return _PublishersDictionary.Select(x => x.Value).ToList(); }
	    set { _publishersDictionary = value.ToDictionary(x => x.Name, x => x); }
	}
	private Dictionary<string, Publisher> _publishersDictionary;
	
	[XmlIgnore]
	public Dictionary<string, Publisher> PublisherDictionary
	{
	    get { return _publishersDictionary; }
	}

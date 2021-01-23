	public IList<string> Items
	{
		get { return items; }
	}
	readonly IList<string> items = new ObservableCollection<string> { "first", "second", "third", "forth" };

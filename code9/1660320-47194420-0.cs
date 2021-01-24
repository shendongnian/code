	public event PropertyChangedEventHandler PropertyChanged;
	private string someProperty;
	public string SomeProperty
	{
		get { return someProperty; }
		set
		{
			someProperty = value;
			OnPropertyChanged();
		}
	}
	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

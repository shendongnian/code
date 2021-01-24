	public Person()
	{
		this.PropertyChanged += this.Person_PropertyChanged;
	}
	private void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(LastName))
		{
			this.OnPropertyChanged(nameof(FullName));
		}
		if (e.PropertyName == nameof(ForeName))
		{
			this.OnPropertyChanged(nameof(FullName));
		}
	}

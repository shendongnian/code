    private string _ForeName;
	public string ForeName
	{
		get
		{ return _ForeName; }
		set
		{
			if (_ForeName != value)
			{
				_ForeName = value;
				OnPropertyChanged(nameof(this.ForeName));
				OnPropertyChanged(nameof(this.FullName));
			}
		}
	}

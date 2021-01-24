	(...)
	
	private bool _isBusy;
	public bool IsBusy
	{
		get { return _isBusy; }
		set
		{
			if (_isBusy == value)
				return;
			_isBusy = value;
			OnPropertyChanged(nameof(IsBusy));
		}
	}
	
	(...)

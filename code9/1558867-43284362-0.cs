    private Users _user;
	public Users SelectedUser
	{
		get
		{
			return _user;
		}
		set
		{
			if (_user == value)
				return;
			_user = value;
			OnPropertyChanged(nameof(SelectedUser));
		}
	}

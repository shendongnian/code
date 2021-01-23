    public ObservableCollection<ClientB2B> Clients
	{
		get
		{
			return _clients;
		}
		set
		{
			if (_clients == value) return;
			_clients = value;
			OnPropertyChanged(); // This is what you need
		}
	}

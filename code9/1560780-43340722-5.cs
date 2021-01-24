	class MyViewModel
	{
		public MyViewModel()
		{
			Records = _database.LoadData();
		}
	}
	class Database
	{
		private ObservableCollection<Record> _data = new ObservableCollection<Record>();
		public ObservableCollection<Record> LoadData()
		{
			EnsureLoaded();
			return _data;
		}
		
		private bool _isLoaded = false;
		private async void EnsureLoaded()
		{
			lock (this)
			{
				if (_isLoaded)
					return;
				
				_isLoaded = true;
			}
			
			//do the actual loading here
			var myResultList = await DoLoadingAsync();
			foreach (myResultList as item)
			{
				_data.Add(item);
			}
		}
	}

    class MyViewModel
    {
    	public MyViewModel()
    	{
    		InitializeAsync();
    	}
    	//warning: async void! 
        public async void InitializeAsync()
        {
            Records = await _database.LoadData();
        }
    }

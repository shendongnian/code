    public void InitializeMyList()
    {
    	MyList = new ObservableCollection<Rate>();
    	for (int i = 0; i < 5; i++)
    	{
    		MyList.Add(new Rate() { ID = i, Interest = 2.0, Insurance = 0.5 });
    	}
    }

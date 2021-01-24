    public MainViewModel()
    {
    	MyItems = new ObservableCollection<MyData>();
    	for (var i = 0;i < 1000;i++)
    		MyItems.Add(new MyData { Id = i, Name = GenerateNames() });
    
    }
    
    private string GenerateNames()
    {
    	var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    	var n = _random.Next(5, 15);
    	return new string(Enumerable.Repeat(chars, n).Select(s => s[_random.Next(s.Length)]).ToArray());
    }

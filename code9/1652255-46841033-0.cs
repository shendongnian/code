    ObservableCollection<int> data = new ObservableCollection<int>();
		
	data.Add(1);
	data.Add(2);
	data.Add(4);
		
	Console.WriteLine(!data.Contains(1));
	Console.WriteLine(!data.Contains(2));
	Console.WriteLine(!data.Contains(4));
	Console.WriteLine(!data.Contains(5));

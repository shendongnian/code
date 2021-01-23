	ObservableCollection<MainItems> _data = new ObservableCollection<MainItems>();
	for (int i = 1; i <= 5; i++)
	{
		MainItems _mainItems = new MainItems();
		_mainItems.ItemName = "Main" + i.ToString();
		_mainItems.SubItemsList = new ObservableCollection<SubItems>();
		for (int j = 1; j <= 3; j++)
		{
			SubItems _subItems = new SubItems()
			{
				SubItemName = "SubItem" + i.ToString()
			};
			_mainItems.SubItemsList.Add(_subItems);
		}
		_data.Add(_mainItems);
	}

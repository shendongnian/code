	private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		ListView view = (ListView)sender;
		//Get Index of Selected Item
		var index = view.SelectedIndex;
		//Get Selected Item
		var selectedItem = view.SelectedItem;
	}

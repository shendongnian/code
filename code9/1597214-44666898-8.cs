	private void testButton1_Click(object sender, RoutedEventArgs e)
	{
		var dd = new BindableDynamicDictionary(); // Creating a dynamic dictionary.
		dd["Age"] = 32; //access like any dictionary
	
		dynamic person = dd; //or as a dynamic
		person.FirstName = "Alan"; // Adding new dynamic properties. The TrySetMember method is called.
		person.LastName = "Evans";
		//hacky for short example, should have a view model and use datacontext
		var collection = new ObservableCollection<object>();
		collection.Add(person);
		dataGrid1.ItemsSource = collection;
	}

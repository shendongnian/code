	List<string> countryList = new List<string>();
	countryList.Add("Select country");
	countryList.Add("USA");
	countryList.Add("Germany");
	
	
	var layoutGridView = new GridView(); //Create layout for ListView.
	
	// Create Display Template and Bindings
	FrameworkElementFactory nameFactory = new FrameworkElementFactory(typeof(TextBlock));
	nameFactory.Name = "tbkName";
	nameFactory.SetBinding(TextBlock.TextProperty, new Binding("Name")); // Assign Property Binding paths for the collection bound to ListView.
	
	FrameworkElementFactory comboFactory = new FrameworkElementFactory(typeof(ComboBox));
	comboFactory.Name = "cmbCountry";
	comboFactory.SetValue(ComboBox.ItemsSourceProperty, countryList); // Assign default list to display in dropdown.
	comboFactory.SetBinding(ComboBox.SelectedValueProperty, new Binding("Country")); // Assign value to select from dropdown.
	
	FrameworkElementFactory checkBoxFactory = new FrameworkElementFactory(typeof(CheckBox));
	checkBoxFactory.Name = "chkSelected";
	checkBoxFactory.SetValue(CheckBox.IsCheckedProperty, new Binding("IsSelected"));
	
	//Define columns with the corresponding cell templates
	layoutGridView.Columns.Add(new GridViewColumn
	{
		Header = "Name",
		CellTemplate = new DataTemplate
		{
			VisualTree = nameFactory    //First(text) column display template
		}
	});
	
	layoutGridView.Columns.Add(new GridViewColumn
	{
		Header = "State",
		CellTemplate = new DataTemplate
		{
			VisualTree = comboFactory   //Second(Combobox) column display template
		}
	});
	
	layoutGridView.Columns.Add(new GridViewColumn
	{
		Header = "Is Selected",
		CellTemplate = new DataTemplate
		{
			VisualTree = checkBoxFactory    //Third(Checkbox) column display template
		}
	});
	
	listView1.View = layoutGridView;    // Assign the display template to ListView.
	
	//Data Binding to listview.
	List<MyData> data = new List<MyData>
	{
		new MyData { Name="Abc", Country= "USA", IsSelected=true},
		new MyData { Name="Def", Country= "Germany", IsSelected=false}
	};
	
	listView1.ItemsSource = data;   //Assign data to ListView's ItemsSource property.

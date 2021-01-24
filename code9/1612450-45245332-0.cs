	//get and declare seralizer, then deserialize
	List<Item> items = serializer.Deserialize<Item>().ToList();
	//find a specific item by name
	string searchName = "UtensilSpoon";
	var mySearchItem = items.FirstOrDefault(i => i.Name == searchName); //null if not found
	//get all the items from a given primary provider
	string primaryProvider = "Farmer";
	var mySearchItems = items.Where(i => i.Primaryprovider == primaryProvider);
	//get all the items in a given category
	string category = "Grocery";
	var itemsInCategory = items.Where(i => i.Categories.Contains(category));
	//get the origin object for items in a given state
	string state = "Texas";
	var texasItems = items.Where(i => i.Origin.State == state);
	//print out the item name, state, and year for texas items only
	string state = "Texas";
	foreach (var item in items.Where(i => i.Origin.State == state))  //(var item in texasItems) would also work
	{
		Console.WriteLine(item.Name);
		Console.WriteLine(item.Origin.State);
		Console.WriteLine(item.Origin.Year);
	}

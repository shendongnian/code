	var realm = Realm.GetInstance();
	var all = realm.All<ARealmClass>();
	Console.WriteLine(all.Count());
	var filterItem = new ARealmClassFilter { Key = 1, FilterKeyBy = 500 };
	realm.Write(() =>
	{
		realm.Add(filterItem);
	});
	var filtered = all.Where(_ => _.Key > filterItem.FilterKeyBy);
	Console.WriteLine(filtered.Count());
	realm.Write(() =>
	{
		filterItem.FilterKeyBy = 750;
		realm.Add(filterItem, true);
	});
	Console.WriteLine(filtered.Count());

	public static (ObservableCollection<T>, ObservableCollection<T>) Partition<T>(this ObservableCollection<T> collection, Func<T, bool> predicate)
	{
		var collection1 = new ObservableCollection<T>();
		var collection2 = new ObservableCollection<T>();
		foreach (T element in collection)
		{
			if (predicate(element))
			{
				collection1.Add(element);
			}
			else
			{
				collection2.Add(element);
			}
		}
		
		return (collection1, collection2);
	}

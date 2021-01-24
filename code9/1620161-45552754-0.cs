    ObservableCollection<int> collection = new ObservableCollection<int>();
	var observable = Observable.FromEventPattern<NotifyCollectionChangedEventArgs>(collection,"CollectionChanged");
	observable.Subscribe(a => { Console.WriteLine("Collection Changed !!!!! ");Debugger.Break(); });
	
	collection.Add(1);

    public How() 
    {
        coll_ = new ObservableCollection<int>();
		coll_.CollectionChanged += (o,e) => 
        { Console.WriteLine("New items: {0}", String.Join (",", e.NewItems.OfType<int>())); };
        field_ = "";
    }

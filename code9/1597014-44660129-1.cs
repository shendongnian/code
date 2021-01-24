	var source = new Subject<IEnumerable<int>>();
	
	var addedElements = source.GetAddedElements();
	var removedElements = source.GetRemovedElements();
	
	addedElements.Dump();   //Using Linqpad
	removedElements.Dump(); //Using Linqpad
	source.OnNext(new int[] { 1, 2, 3, 4 });
	source.OnNext(new int[] { 1, 3, 4 });
	source.OnNext(new int[] { 1, 5, 6 });

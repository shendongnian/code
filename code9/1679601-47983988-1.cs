	var publishedSource = stuff.Publish();
	var firstTenItems = publishedSource.Take(10).ToArray();
	var nextTwentyTransformedItems = publishedSource.Take(20).Select(Mutate).ToArray();
	// How you apply 'Where' depends on what you want to achieve.
	// This returns the next 5 items that match the filter but if there are less
    // than 5 items that match the filter you could end up enumerating the
    // entire remainder of the sequence.
	var nextFiveFilteredItems = publishedSource.Where(Filter).Take(5).ToArray(); 
	// This enumerates _only_ the next 5 items and yields any that match the filter.
	var nextOfFiveItemsThatPassFilter = publishedSource.Take(5).Where(Filter).ToArray()

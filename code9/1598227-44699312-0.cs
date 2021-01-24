    List<OfferPriority> OfferPriorities = new List<OfferPriority>();
	OfferPriorities.Add(new OfferPriority() { TypeId = 1 });
	OfferPriorities.Add(new OfferPriority() { TypeId = 2 });
	//OfferPriorities.Add(new OfferPriority() { TypeId = 3 });
	List<int> allowedIDs = new List<int> { 1, 2, 3 };
	bool check = allowedIDs.All(x => OfferPriorities.Select(y => y.TypeId).Contains(x));

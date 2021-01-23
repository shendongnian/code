    // Left join the current month with the last month
	var currentMonth = 
		from current in resourcesThisMonth
		join last in resourcesLastMonth on new { current.SubscriptionId, current.ItemId } equals new { last.SubscriptionId, last.ItemId } into outer
		from o in outer.DefaultIfEmpty()
		select new Resource
		{
			SubscriptionId = current.SubscriptionId,
			ItemId = current.ItemId,
			UnitsThisMonth = current.Units,
			UnitsLastMonth = o?.Units ?? 0, // Replace NULL with 0
			EffectiveRate = current.EffectiveRate,
			ResourceName = current.ResourceName,
			UnitOfMeasure = current.UnitOfMeasure
		};
	
	// Reverse of the first join.  Last month LEFT JOIN Current month
	var lastMonth = 
		from last in resourcesLastMonth
		join current in resourcesThisMonth on new { last.SubscriptionId, last.ItemId } equals new { current.SubscriptionId, current.ItemId } into outer
		from o in outer.DefaultIfEmpty()
		select new Resource
		{
			SubscriptionId = last.SubscriptionId,
			ItemId = last.ItemId,
			UnitsThisMonth = o?.Units ?? 0, // Replace NULL with 0
			UnitsLastMonth = last.Units,
			EffectiveRate = o?.EffectiveRate ?? last.EffectiveRate,
			ResourceName = o?.ResourceName ?? last.ResourceName,
			UnitOfMeasure = o?.UnitOfMeasure ?? last.UnitOfMeasure
		};
	
	// Union them together to get a full join
	var resources = currentMonth.Union(lastMonth);

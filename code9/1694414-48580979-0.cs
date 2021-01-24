	// Create test product data
	var orderingEquipments = Builder<OrderingEquipment>.CreateListOfSize(20)
		.All()
		.With(p => p.Guid = Guid.NewGuid())
		.With(p => p.Timestamp = DateTime.UtcNow.AddMonths(new Random().Next(1)))
		.With(p => p.Timestamp = DateTime.UtcNow.AddDays(new Random().Next(2)))
		.TheFirst(5)
		.With(p => p.Text = "First five")
		.Build()
		.ToList();
	
	var queryable = orderingEquipments.AsQueryable();
		
	dbSet = Substitute.For<IDbSet<OrderingEquipment>>();
	dbSet.Provider.Returns(queryable.Provider);
	dbSet.Expression.Returns(queryable.Expression);
	dbSet.ElementType.Returns(queryable.ElementType);
	dbSet.GetEnumerator().Returns(queryable.GetEnumerator());
	dbSet.Find(Arg.Any<object[]>()).Returns(callinfo => {
		object[] idValues = callinfo.Arg<object[]>();
		if (idValues != null && idValues.Length == 1) {
			Guid requestedId = (Guid)idValues[0];
			return queryable.FirstOrDefault(p => p.Guid == requestedId);
		}
		return null;
	});
	//Setup remove on db set to remove actual item from fake collection
	dbSet.Remove(Arg.Any<OrderingEquipment>())
		.Returns(callInfo => {
			var item = callInfo.Arg<OrderingEquipment>();
			return item != null && orderingEquipments.Remove(item);
		});
			

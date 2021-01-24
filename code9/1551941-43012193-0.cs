		int oldOrder = 8;
		int newOrder = 3;
		
		if (newOrder < oldOrder) {
			SmallBit moving = collection.Where(c => c.Order == oldOrder).First();
			collection.Where(c => c.Order >= newOrder && c.Order < oldOrder).ToList().ForEach(c => c.Order += 1);
			moving.Order = newOrder;
			
		} else {
			SmallBit moving = collection.Where(c => c.Order == oldOrder).First();
			collection.Where(c => c.Order > oldOrder && c.Order <= newOrder).ToList().ForEach(c => c.Order -= 1);
			moving.Order = newOrder;
			
		}

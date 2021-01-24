	var toBeDeletedBList = toBeDeletedB.ToList();
	
	var listA = toBeDeletedBList.Where(x => x.Type == TypeId);
	var listB = toBeDeletedBList.Where(x => x.Type != TypeId);
	
	var rlRows = dbContext.DBTable.Where(x => x.Type == typeId && listA.Contains(s.Url);
	
	listB.ForEach(s => {
		dbContext.DBTable.Attach(s);
		dbContext.DBTable.Remove(s);
	});

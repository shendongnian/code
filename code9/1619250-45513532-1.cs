	public void Edit(Entity entity)
	{
		var db = context
			.Include(i => i.Subset1)
			.Where(i => i.ID == id)
			.Single();
	
		// update entity
		context.Entry(db).CurrentValues.SetValues(entity);
	
		// delete / clear subset1 from database
		foreach (var dbSubset1 in db.Subset1.ToList())
		{
			if (!entity.Subset1.Any(i => i.ID == dbSubset1.ID))
				context.Subset1.Remove(dbSubset1);
		}
	
		foreach (var newSubset1 in entity.Subset1)
		{
			var dbSubset1 = db.Subset1.SingleOrDefault(i => i.ID == newSubset1.Id);
			if (dbSubset1 != null)
				// update Subset1
				context.Entry(dbSubset1).CurrentValues.SetValues(newSubset1);
			else
				db.Subset1.Add(newSubset1);
		}
	
		// save
		db.SaveChanges();
	}

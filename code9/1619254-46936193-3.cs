	Person.Name = "Foo";
	Person.ObjectState = ObjectState.Modified;
	Phone toBeDeleted = myObject.Phones.FirstOrDefault(x => x.Number == "555");
	if(toBeDeleted!=null)
		toBeDeleted.ObjectState = ObjectState.Deleted;
	Phone toBModified = myObject.Phones.FirstOrDefault(x => x.Number == "444");
	if(toBModified!=null)
	{
		toBModified.Number = "333";
		toBeDeleted.ObjectState = ObjectState.Modified;
	}
		
	ApplyChanges(myObject);
	private void ApplyChanges<TEntity>(TEntity root) where TEntity : class, IObjectWithState
	{
		using (var context = new MyContext(connectionString))
		{
			context.Set<TEntity>().Add(root);
			CheckForEntitiesWithoutStateInterface(context);
			foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
			{
				IObjectWithState stateInfo = entry.Entity;
				entry.State = ConvertState(stateInfo.ObjectState);
			}
			context.SaveChanges();
		}
	}
	private System.Data.Entity.EntityState ConvertState(ObjectState state)
	{
		switch (state)
		{
			case ObjectState.Added:
				return System.Data.Entity.EntityState.Added;
			case ObjectState.Modified:
				return System.Data.Entity.EntityState.Modified;
			case ObjectState.Deleted:
				return System.Data.Entity.EntityState.Deleted;
			default:
				return System.Data.Entity.EntityState.Unchanged;
		}
	}
	private void CheckForEntitiesWithoutStateInterface(MyContext context)
	{
		var entitiesWithoutState = context.ChangeTracker.Entries().Where(x => !(x.Entity is IObjectWithState));
		if (entitiesWithoutState.Any())
		{
			throw new NotSupportedException("All entities must implement IObjectWithState");
		}
	}

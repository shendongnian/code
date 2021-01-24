	try
	{
		/* For avoiding "Attaching an entity of type 'Xxxxx' failed because another entity of 
        the same type already has the same primary key value." error use this method like this */
		using (var context = new Context.Entry<TEntity>())
		{
			context.Entry(entity).State = EntityState.Modified; // modified
			context.SaveChanges(); //Must be in using block
			result = true;
		}
	}

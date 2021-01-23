    public async Task Save(Property property)
    {	
	    using (var context = new SomeDbContext())
	    {
		    var existingProperty = context.Property.FirstOrDefaultAsync(f => f.Id == property.Id);
		    if (existingProperty == null)
		    {
			    context.Property.Add(property);
		    }
		    else
		    {
			    //maybe use automapper here if there is a lot of this stuff going on
			    //EF is smart enough to figure out what needs updating and will write a terse update statment
			    //no attach is needed since your existingProperty still exist within your context
			    existingProperty.Name = property.Name;
			    existingProperty.BranchId = property.BranchId;
			    existingProperty.Branch = property.Branch;
		    }
		    await context.SaveChangesAsync();
	    }
	
    }

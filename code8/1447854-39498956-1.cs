    public Task Upsert(Property property)
    {
        using (var context = new SomeDbContext())
        {
    		//if the id is autoincrement field then you will need to pass the new id to the property if it changes.
    		await Save(new Branch{ Id = property.BranchId, Name = property.Branch}, context);
    		await Save(property, context);
    		await context.SaveChangesAsync();
    	}
    }
    private Task Save(Property property, SomeDbContext context)
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
    
    }
    private Task Save(Branch branch, SomeDbContext context)
    {   
    
    	var existingBranch = context.Branch.FirstOrDefaultAsync(f => f.Id == branch.Id);
    	if (existingBranch == null)
    	{
    		context.Branch.Add(branch);
    	}
    	else
    	{
    		existingBranch.Name = branch.Name;
    	}
    }

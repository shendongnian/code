    public bool UpdatePerson entity)
    {
    
       //_context.Set<Person>().AddOrUpdate(entity);
       var entityInDb = _context.Persons.Include(x => x.Operations).FirstOrDefault(x => x.Id == entity.Id);//Add Include for navigation property
    
       _context.Entry(entityInDb).CurrentValues.SetValues(entity);
       _context.Entry(entityInDb).State = EntityState.Modified;
       _context.Entry(entityInDb).Property(x => x.Operations).IsModified = true; // Add this line
       return _context.SaveChanges() > 0;
    }

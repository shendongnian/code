    public void Delete(Entity E) 
    {
        var existingEntity = _context.EntityTable.SingleOrDefault(s => s.Code == E.Code);
        _context.EntityTable.Remove(existingEntity);
        Save()
    }
    
    public void Insert(Entity E)
    {
        var existingEntity = _context.EntityTable.FirstOrDefault(s => s.Code == E.Code);
        if (existingEntity != null){
            throw new ArgumentException("Item alread exists.")
        }
    
        var newEntity = CreateDbEntity(E); // Create Db Entity just convert the type. Nothing much here.
        _context.EntityTable.Add(newEntity);
        Save()
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }

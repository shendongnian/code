    public void UpdateClientScope(ClientScope scope){
    
    // Get the existing object from the DB
    ClientScope dbScope = _dbContext.ClientScope.FirstOrDefault(x => x.Id == scope.Id);
    
    // Test it was in DB
    if (dbScope != null)
    {
      // Update the database object
      dbScope.Scope = scope.Scope;
      dbScope.Client = scope.Client;
      // SaveChanges works on dbScope
      _dbContext.SaveChanges();
    }
    else
    {
      // Object not found, some error processing
    }
    }

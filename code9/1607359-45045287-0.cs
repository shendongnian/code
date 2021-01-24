       var centralPoint = _context.CentralPoint.Where(cp => cp.ID == cpId)
            .Include(cp => cp.BIDatabase)
            .ThenInclude(biDb => biDb.Connection)
            .FirstOrDefault();
    
       biDatabase.Connection = (centralPoint?.BIDatabase?.Connection) ?? biDatabase.Connection;
        centralPoint.BIDatabase = biDatabase;
        await _context.SaveChangesAsync();

    async Task<string> GetName(long userId)
    {
    string information="";  // loading data with entity
    DbContext context = _context// Your dbContext
    await Task.Run(() => UpdateActivity(userId, context));
    
    
    return information;
    }
    void UpdateActivity(int userId, DbContext context)
    {
       //perform dboperation with context
    }

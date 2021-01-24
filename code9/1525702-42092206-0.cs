    [Route("api/FirstTest/{SysId}")]
    public List<String> Name(long SysId)
    { 
       using (var db = new AContext())
       {
         return db.firsttests   // here the type is IQueryable<firsttest>
                  .Where(a => a.SysId.Equals(SysId)) 
                  .Select(a => a.Name) // here the type is IQueryable<string>
                  .ToList();  // here the type of List<string>
       }
    }

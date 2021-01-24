    public GenericRepository<T> GetRepo<T>() 
      where T : class
    {
      return new GenericRepository<T>(_context);
    }
    public async Task SetDateLastInvoked<T>(int id)
      where T : class, IBaseData
    {
      var tmp = GetRepo<T>().FirstOrDefault(obj => obj.Id == id));
      tmp.DateLastInvoked = DateTime.Now;
      await SaveChangesAsync();
    }

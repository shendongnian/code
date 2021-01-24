    public async Task<int> ReadAsync()
    {
      try
      {
        return Task.Factory.FromAsync(classToBeWrapped.BeginRead,...);
      }
      catch (ExceptionToBeWrapped ex)
      {
        throw new WrappedException(ex);
      }
    }

    private async Task UpdateTableAsync(string desc)
    {
      ...
      await db.SaveChangesAsync();
    }
    private async Task<object> GetObjectValue(string desc)
    {
      object objA = await ...;
      return objA;
    }

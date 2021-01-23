    public static async Task LogExceptions(Func<Task> func)
    {
      try
      {
        await func();
      }
      catch (Exception ex)
      {
        Logger.Log(ex.ToString());
      }
    }
    public static async Task<T> LogExceptions<T>(Func<Task<T>> func)
    {
      try
      {
        return await func();
      }
      catch (Exception ex)
      {
        Logger.Log(ex.ToString());
      }
    }

    internal object AsyncExecuteWrapper(int type, CommandBehavior behavior)
    {
      thrownException = null;
      try
      {
        if (type == 1)
          return ExecuteReader(behavior);
        return ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        thrownException = ex;
      }
      return null;
    }

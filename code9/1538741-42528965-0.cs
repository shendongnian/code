    class TEntity
    {
      public void Write<TEntity>(Func<TEntity, long> func, string info)
      {
          var id = func(this);
      }
    }

    public class ConfigurationServices
    {
      Func<Owned<DbContext>> _contextFactory;
      public ConfigurationServices(Func<Owned<DbContext>> contextFactory)
      {
        this._contextFactory = contextFactory;
      }
      public void DoWork()
      {
        using(var context = this._contextFactory().Value)
        {
          context.DoSomethingInDatabase();
        }
      }
    }

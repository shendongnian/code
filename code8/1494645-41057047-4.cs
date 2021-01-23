    public static List<_Account> Get(_User user, Context contextProvided = null, ...)
    {
      using (var contextProvider = new ContextProvider(contextProvided))
      {
        Context context = contextProvider.EffectiveContext;
        //...
      }
    }

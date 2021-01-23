    public class SomeClassUsingEF {
      // DI
      private readonly IEntityContextProvider _entityContextProvider;
      // DI
      public SomeClassUsingEF(IEntityContextProvider entityContextProvider)
      {
         if (entityContextProvider == null)
           throw new ArgumentNullException(nameof(entityContextProvider));
         _entityContextProvider = entityContextProvider;
      }
      public void SomeQueryToDB() {
        using(var context = _entityContextProvider.CreateContext()) {
          // select/insert/updates here
        }
      }
    }

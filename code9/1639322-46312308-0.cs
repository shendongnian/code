Project <company>.DataAccess.csproj
    namespace <companyname>.DataAccess
    {
      // sometimes generic IMyDomainDA<IEntityType>
      public interface IMyDomainDA // I suffix it with DA for DataAccess
      {
        IEntityType Get();
        // etc
      }
    }
Project <company>.DataAccess.<ImplementationType>.csproj

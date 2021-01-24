    public class RepositoryService : IRepositoryService
    {
    
        public RepositoryService (IServiceA serviceA, IServiceB serviceB) 
        {
            /* ... */
        }
        
        public void SomeMethod()
        {
        }     
    }
    public abstract class Repository
    {
        protected IRepositoryService repositoryService;
    
        public (IRepositoryService repositoryService)   
        {
          this.repositoryService= repositoryService;
        }
    
        public virtual void SomeMethod()
        {
              this.repositoryService.SomeMethod()
 
              .
              .
        }
    }
    public class ChildRepository1 : Repository
    {
   
        public (IRepositoryService repositoryService)  : base (repositoryService)
        {
        }
    
        public override void SomeMethod()
        {
              .
              .
        }
    }
    public class ChildRepository2 : Repository
    {
   
        public (IRepositoryService repositoryService, ISomeOtherService someotherService)   : base (repositoryService)
        {
              .
              .
        }
    
        public override void SomeMethod()
        {
              .
              .
        }
    }

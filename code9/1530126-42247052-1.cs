    public interface ILocator<T> // defined in some *CORE* project
    {
      T Locate();
    }
    
    public class AutofacLocator<T> : ILocator<T> // defined and injected in your *FRONTEND* project
    {
      public AutofacLocator(ILifetimeScope lifetimeScope)
      {
        this.LifetimeScope = lifetimeScope;
      }
    
      public virtual T Locate()
      {
        var service = this.LifetimeScope.Resolve<T>();
    
        return service;
      }
    }

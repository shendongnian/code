    public interface ILocator<T>
    {
      T Locate();
    }
    
    public class AutofacLocator<T> : ILocator<T>
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

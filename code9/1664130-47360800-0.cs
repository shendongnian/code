    public interface IFilterFactory
    {
        TFilter Get() where TFilter : IFilter; 
    }
    public class FilterFactory : IFilterFactory
    {
        public FilterFactory(ILifetimeScope scope)
        {
            this._scope = scope; 
        }
        
        private readonly ILifetimeScope _scope; 
        public TFilter Get<TFilter>()
        {
            return this._scope.Resolve<TFilter>(); 
        }
    }

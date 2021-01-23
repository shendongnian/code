    public class ClientClass
    {
        private readonly ILifetimeScope _scope;
    
        public ClientClass(ILifetimeScope scope)
        {
            _scope = scope;
        }
    
        public void DoSomething<T>()
        {
            var myGeneric = _scope.Resolve<IGeneric<T>>();
        }
    }

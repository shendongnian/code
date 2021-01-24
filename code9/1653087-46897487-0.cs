    public class UnitOfWorkDecorator<TRequest, THandler> : IHandler<TRequest>
            where TRequest : class
            where THandler : IHandler<TRequest>
        {
            protected readonly Func<ILifetimeScope> ParentScope;
    
            public UnitOfWorkDecorator(Func<ILifetimeScope> parentScope)
            {
                ParentScope = parentScope;
            }
    
            public void Handle(TRequest request)
            {
                Console.WriteLine("UoW handler start");
    
                using (var scope = ParentScope().BeginLifetimeScope())
                {
                    var scopedHandler = scope.Resolve<THandler>();
                    scopedHandler.Handle(request);
                }
                
                Console.WriteLine("UoW handler end");
            }
        }

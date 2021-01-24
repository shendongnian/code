    namespace Foo.Services.Impl.UnitOfWork
    {
        public class UnitOfWorkFooService : IFooService
        {
            private readonly IUnitOfWork _uow;
            public UnitOfWorkFooService( IUnitOfWork uow )
            { 
                _uow = uow;
            }
    
            public Task<Foo> GetByIdAsync( int id );
            {
                return await _uow.FooRepo.FindOne( ... ).FirstOrDefaultAsync();
            }
        }
    }

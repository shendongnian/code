    public class FooRepository :
    GenericRepository<FooBarEntities, Foo>, IFooRepository {
    public Foo GetSingle(int fooId) {
        var query = GetAll().FirstOrDefault(x => x.FooId == fooId);
        return query;
    }
    }

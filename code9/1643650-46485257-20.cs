    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(TestRepositoryBase<>),
        typeof(TestRepositoryBase<,>)
    )]
    public class TestDbContext : AbpDbContext
    {
        ...
    }

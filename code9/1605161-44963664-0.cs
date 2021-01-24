    [AutoRepositoryTypes(
    typeof(IRepository<>),
    typeof(IRepository<,>),
    typeof(SimpleTaskSystemEfRepositoryBase<>),
    typeof(SimpleTaskSystemEfRepositoryBase<,>)
    )]
    public class SimpleTaskSystemDbContext : AbpDbContext
    {
         ...
    } 

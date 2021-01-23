    // Common Interfaces
    public interface ICommonDbSets
    {
        IDbSet<DataOne> DataOnes { get; }
        IDbSet<DataTwo> DataTwos { get; }
    }
    public interface IUnitOfWork<TUser>
    {
        Task<int> SaveChangesAsync(TUser user);
    }
    // Specific interface aggregation
    public interface IIntegrationDbContext : ICommonDbSets, IUnitOfWork<Customer>
    {
    }
    public interface IProfessionalDbContext : ICommonDbSets, IUnitOfWork<ProfessionalUser>
    {
    }
    public interface IPublicDbContext : ICommonDbSets, IUnitOfWork<PublicDomain>
    {
    }
    // Base class to enforce contract
    public abstract class AbstractDbContext<TUser> : ICommonDbSets, IUnitOfWork<TUser>
    {
        private readonly DbContext _dbContext;
        protected AbstractDbContext(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IDbSet<DataOne> DataOnes
        {
            get { return _dbContext.Set<DataOne>(); }
        }
        public IDbSet<DataTwo> DataTwos
        {
            get { return _dbContext.Set<DataTwo>(); }
        }
        public abstract Task<int> SaveChangesAsync(TUser user);
    }
    // Specific implementations
    public sealed class IntegrationDbContext : AbstractDbContext<Customer>, IIntegrationDbContext
    {
        public IntegrationDbContext(DbContext dbContext) : base(dbContext)
        {
        }
        public override Task<int> SaveChangesAsync(Customer user)
        {
            throw new NotImplementedException();
        }
    }
    public sealed class ProfessionalDbContext : AbstractDbContext<ProfessionalUser>, IProfessionalDbContext
    {
        public ProfessionalDbContext(DbContext dbContext) : base(dbContext)
        {
        }
        public override Task<int> SaveChangesAsync(ProfessionalUser user)
        {
            throw new NotImplementedException();
        }
    }
    public sealed class PublicDbContext : AbstractDbContext<PublicDomain>, IPublicDbContext
    {
        public PublicDbContext(DbContext dbContext) : base(dbContext)
        {
        }
        public override Task<int> SaveChangesAsync(PublicDomain user)
        {
            throw new NotImplementedException();
        }
    }

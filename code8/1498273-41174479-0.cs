    public interface IIntegrationDbContext<TUser>
    {
        IDbSet<DataOne> DataOnes { get; set; }
        IDbSet<DataTwo> DataTwos { get; set; }
        Task<int> SaveChangesAsync(TUser user);
    }

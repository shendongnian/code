    public interface IMyLoggingModel : IDisposable {
        DbSet<Log> Log { get; set; }
        Task<int> SaveChangesAsync();
    
        //...other needed members.
    }

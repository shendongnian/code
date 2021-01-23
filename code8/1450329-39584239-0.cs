        public interface IMyDbContextReadonly : IMyDbContext { }
    
    public class MyDbContextReadonly : MyDbContext, IMyDbContextReadonly
    {
        public MyDbContextReadonly(string connectionString, bool proxyCreationEnabled, bool lazyLoadingEnabled, bool autoDetectChangesEnabled)
            : base(connectionString)
        {            
            this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            this.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            this.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
        }
    }

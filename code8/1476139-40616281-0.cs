    using System;
    using System.Data.Entity;
    using System.Linq;
    namespace SqlServerDatabaseBackup
    {
        public class Table
        {
            public int TenantId { get; set; }
            public int TableId { get; set; }
        }
        public interface ITentantIdProvider
        {
            int TenantId();
        }
        public class TenantRepository : ITenantRepositoty
        {
            private int tenantId;
            private ITentantIdProvider _tentantIdProvider;
            private TenantContext context = new TenantContext(); //You can abstract this if you want
            public IQueryable<Table> Tables
            {
                get
                {
                    return context.Tables.Where(t => t.TenantId == tenantId);
                }
            }
            public TenantRepository(ITentantIdProvider tentantIdProvider)
            {
                _tentantIdProvider = tentantIdProvider;
                tenantId = _tentantIdProvider.TenantId();
            }
        }
        public interface ITenantRepositoty
        {
            IQueryable<Table> Tables { get; }
        }
        public class TenantContext : DbContext
        {
            public DbSet<Table> Tables { get; set; }
        }
        public interface IService
        {
            void DoWork();
        }
        public class Service : IService
        {
            private ITenantRepositoty _tenantRepositoty;
            public Service(ITenantRepositoty tenantRepositoty)
            {
                _tenantRepositoty = tenantRepositoty;
            }
            public void DoWork()
            {
                _tenantRepositoty.Tables.ToList();//These are filtered records
            }
        }  
    }
 

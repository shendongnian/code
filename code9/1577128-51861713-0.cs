    namespace Search
    {
        using System;
        using System.Data.Entity;
        using System.Data.Entity.Infrastructure;
    
        public partial class XYZ_MSCRMEntities : DbContext
        {
           public XYZ_MSCRMEntities()
            : base("name=xyz_MSCRMEntities")
           {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AnyDatabaseTableOrView> TableOrViewPluralized { get; set; }
        }}

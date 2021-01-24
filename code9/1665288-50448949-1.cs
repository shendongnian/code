    namespace main2
    {
        using System;
        using System.Configuration;
        using System.Data.Entity;
        using System.Data.Entity.Infrastructure;
        
        public partial class dbEntities : DbContext
        {
            public crypto_dbEntities()
                : base(ConfigurationManager.ConnectionStrings["dbEntities"].ConnectionString)
            {
            }
        
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                throw new UnintentionalCodeFirstException();
            }
    }

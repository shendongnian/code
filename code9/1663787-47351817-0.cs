    class MyDbContext : DbContext
    {
        public DbSet<VisitModel> VisitModels {get; set;}
        public DbSet<VistitorModel> VistiroModels {get; set}
    }

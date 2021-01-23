     public class UCAS_dbContext :BaseContext<UCAS_dbContext>
    {
        public DbSet<SyncCodesEntity> SyncCodes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("UCAS");
        }
    }

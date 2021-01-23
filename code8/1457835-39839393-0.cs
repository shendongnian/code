    public partial class YourContext : DbContext
    {
        private int _tenantId;
        public override int SaveChanges() {
            var addedEntities = this.ChangeTracker.Entries().Where(c => c.State == EntityState.Added)
                .Select(c => c.Entity).OfType<IMultiTenantEntity>();
            foreach (var entity in addedEntities) {
                entity.TenantID = _tenantId;
            }
            return base.SaveChanges();
        }
        public IQueryable<Code> TenantCodes => this.Codes.Where(c => c.TenantID == _tenantId);
    }

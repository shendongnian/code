    public abstract class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public virtual void PrepareSave(EntityState state)
        {
            var identityName = Thread.CurrentPrincipal.Identity.Name;
            var now = DateTime.UtcNow;
            if (state == EntityState.Added)
            {
                CreatedBy = identityName ?? "unknown";
                CreatedDate = now;
            }
            UpdatedBy = identityName ?? "unknown";
            UpdatedDate = now;
        }
    }

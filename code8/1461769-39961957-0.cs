    public class ApplicationUser
    {
        ...
        public class Mapping : EntityTypeConfiguration<ApplicationUser>
        {
            HasMany(m => m.Issues).WithRequired(m => m.Customer);
        }
    }

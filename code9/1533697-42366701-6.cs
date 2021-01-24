    internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Personal>
    {
        public Configuration()
        {
            HasKey(p => p.ApplicationUserID);
            HasRequired(current => current.ApplicationUser)
                .WithOptional(user => user.PersonalU)
                .WillCascadeOnDelete(true);
        }
    }

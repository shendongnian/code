    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(x => x.Id);
            HasMany(x => x.Locations);
        }
    }

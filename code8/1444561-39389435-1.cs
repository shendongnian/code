    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.HasKey<int>(p => p.Id);
            this.Property(u => u.UserPin).IsRequired().HasMaxLength(2000);
        }
    }

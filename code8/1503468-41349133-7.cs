    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("TblUser");
            HasKey(x => x.Id);
            Property(x => x.Example1)
                .IsRequired();
            //etc
        }
    }

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //declaring the table name
            ToTable("TblUser");
            //declaring primary key of the table
            HasKey(x => x.Id);
            //declaring a property from poco class is required
            Property(x => x.Example1)
                .IsRequired();
            //etc
        }
    }

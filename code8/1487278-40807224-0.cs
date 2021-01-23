    public class ClassAppContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public ClassAppContext() : base("name=ClassAppDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ClassAppContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());
            modelBuilder.Configurations.AddFromAssembly(typeof(PostMap).Assembly);
        }
    }
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            ToTable("Post");
            HasKey(x => x.PostId)
                .Property(x => x.PostId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(250);
            Property(x => x.Content)
                .HasColumnType("nvarchar")
                .HasMaxLength(500);
        }
    }

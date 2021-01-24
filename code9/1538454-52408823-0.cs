    namespace tpc_so
    {
        public class tpc_soContext : DbContext
        {
            public tpc_soContext()
            {
            }
            public DbSet<BaseEntity> BaseEntities { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<BaseEntity>().HasKey(b => b.BaseEntityId);
                modelBuilder.Entity<BaseEntity>()
               .Property(b => b.BaseEntityId)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    
                modelBuilder.Entity<FirstDerivedEntity>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("FirstDerivedEntities");
                });
    
                modelBuilder.Entity<SecondDerivedEntity>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("SecondDerivedEntities");
                });
    
    
                modelBuilder.Entity<Comment>().ToTable("Comments");
    
                base.OnModelCreating(modelBuilder);
            }
    
        }
        public abstract class BaseEntity
        {
            public Guid BaseEntityId { get; set; }
            public virtual ICollection<Comment> Comments { get; set; }
        }
    
        public class FirstDerivedEntity : BaseEntity{}
        public class SecondDerivedEntity : BaseEntity{ }
    
        public class Comment
        {
            public long CommentId { get; set; }
            public Guid BaseEntityId { get; set; }
            public string Text { get; set; }
        }
    
    }
   

    namespace TestEF6.Data
    {
        using System;
        using System.Data.Entity;
    
        public partial class ProjectManagerContext : DbContext
        {
            public ProjectManagerContext()
                : base("name=ProjectManager")
            {
            }
    
            public virtual DbSet<ORDER> ORDERs { get; set; }
            public virtual DbSet<PROJECT> PROJECTs { get; set; }
            
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                Database.Log = Console.WriteLine;
    
                modelBuilder.Entity<PROJECT>()
                .HasMany(p => p.ORDERS)
                .WithMany(o => o.PROJECTS)
                .Map(pc =>
                {
                    pc.MapLeftKey("PROJECT_ID");
                    pc.MapRightKey("ORDER_ID");
                    pc.ToTable("PROJECT_ORDER");
                });
            }
        }
    }

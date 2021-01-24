    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    
    namespace Ef6Test
    {
    
        public abstract partial class Environment
        {
            public int Id { get; set; } // EnvironmentId (Primary key)
    
            public Environment()
            {
                InitializePartial();
            }
    
            partial void InitializePartial();
        }
    
        public partial class BaEnvironment : Environment
        {
            // MAY have a portal environment
            [InverseProperty("BaEnvironment")]
            public virtual ICollection<PortalEnvironment> PortalEnvironments { get; } = new HashSet<PortalEnvironment>();
    
            public BaEnvironment()
            {
                InitializePartial();
            }
    
            partial void InitializePartial();
        }
    
        public partial class PortalEnvironment : Environment
        {
            // MUST have a BAMS environment
            [ForeignKey("BaEnvironmentID")]
            public virtual BaEnvironment BaEnvironment { get; set; } // PortalEnvironment.FK_PortalEnvironment_BAEnvironment
    
            [Required(), Index(IsUnique = true)]
            public int BaEnvironmentID { get; set; }
    
            public PortalEnvironment()
            {
                InitializePartial();
            }
    
            partial void InitializePartial();
        }
        class Db : DbContext
        {
            public DbSet<Environment> Environment { get; set; }
            public DbSet<BaEnvironment> BaEnvironment { get; set; }
            public DbSet<PortalEnvironment> PortalEnvironment { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Environment>().ToTable("Environment");
                modelBuilder.Entity<BaEnvironment>().ToTable("BaEnvironment");
                modelBuilder.Entity<PortalEnvironment>().ToTable("PortalEnvironment");
    
                modelBuilder.Entity<PortalEnvironment>().HasRequired<BaEnvironment>(e => e.BaEnvironment).WithMany();
                base.OnModelCreating(modelBuilder);
            }
        }
    
    
    
    
        class Program
        {
            static void Main(string[] args)
            {
        
                Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
    
                using (var db = new Db())
                {
    
                    db.Database.Log = m => Console.WriteLine(m);
                    db.Database.Initialize(true);
    
                    
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }

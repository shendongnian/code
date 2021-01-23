    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    
    namespace TestApplication.Models
    {
    	
    	/// <summary>
        /// The context class. Make your migrations from this point.
        /// </summary>
        public partial class TestApplicationContext : DbContext
        {
            public virtual DbSet<Company> Companies { get; set; }
    
            public TestApplicationContext(DbContextOptions<TestApplicationContext> options) : base(options)
            {
    
            }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // standard stuff here...
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Company>(entity =>
                {
                    entity.Property<Guid>("CompanyId")
                            .ValueGeneratedOnAdd();
    
                    entity.Property<int>("CompanyIndex")
                            .UseSqlServerIdentityColumn()
                            .ValueGeneratedOnAdd();
    
                    entity.Property(e => e.CompanyName)
                        .IsRequired()
                        .HasColumnType("varchar(100)");
    
    				// ... Add props here.
    
                    entity.HasKey(e => e.CompanyId)
                        .ForSqlServerIsClustered(false)
                        .HasName("PK_Company");
                    entity.HasIndex(e => e.CompanyIndex)
                        .ForSqlServerIsClustered(true)
                        .HasName("IX_Company");
                });
            }
        }
            /// <summary>
            /// The model - put here for brevity.
            /// </summary>
        	public partial class Company
            {
                public Company()
                {
                }
        
                public Guid CompanyId { get; set; }
                public int CompanyIndex { get; set; }
        
                public string CompanyName { get; set; }
        		// more props here.
            }
    
        }

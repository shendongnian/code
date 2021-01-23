    public class ClassAType
    {
    	public string Code { get; private set; }
    	public string Name { get; private set; }
    	public int Flags { get; private set; }
    
    
    	// Reverse navigation
    	//public virtual System.Collections.Generic.ICollection<ClassA> ClassAs { get; set; }
    }
    
    public class ClassATypeConfiguration  : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ClassAType>
    	{
    	public ClassATypeConfiguration()
    		: this("dbo")
    	{
    	}
    
    	public ClassATypeConfiguration(string schema)
    	{
    		ToTable("TEST_ClassAType", schema);
    		HasKey(x => x.Code);
    
    		Property(x => x.Code).HasColumnName(@"Code").IsRequired().HasColumnType("varchar").HasMaxLength(12);
    		Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("varchar").HasMaxLength(50);
    		Property(x => x.Flags).HasColumnName(@"Flags").IsRequired().HasColumnType("int");
    
    	}
    }
---
    public class MyDbContext : System.Data.Entity.DbContext
    {
    	public System.Data.Entity.DbSet<ClassA> ClassAs { get; set; }
    	public System.Data.Entity.DbSet<ClassAType> ClassATypes { get; set; }
    
    	static MyDbContext()
    	{
    		System.Data.Entity.Database.SetInitializer<MyDbContext>(null);
    	}
    
    	const string connectionString = @"Server=TESTDB; Database=TEST; Integrated Security=True;";
    
    	public MyDbContext()
    		: base(connectionString)
    	{
    	}
    
    	protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    		modelBuilder.Configurations.Add(new ClassAConfiguration());
    		modelBuilder.Configurations.Add(new ClassATypeConfiguration());
    	}
    }

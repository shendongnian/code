    class Program
    {
    	static void Main(string[] args)
    	{
    		ConcurrentDictionary<int,ClassA> theCache = null;
    
    		try
    		{
    			using(var ctx = new MyDbContext())
    			{
    				var classAs = ctx.ClassAs
    					.Include(a => a.ClassAType)
    					.ToList();
    				
    				theCache = new ConcurrentDictionary<int,ClassA>(classAs.ToDictionary(a => a.ID));
    			}
 
                // take 2 instances of ClassA that refer to the same ClassAType
                // and load them into separate DbContexts   
    			var classA1 = theCache[1];
    			var classA2 = theCache[2];
    			
    			var ctx1 = new MyDbContext();
    			ctx1.ClassAs.Attach(classA1);
    
    			var ctx2 = new MyDbContext();
    			ctx2.ClassAs.Attach(classA2);
                // When ClassAType has a reverse FK navigation property to
                // ClassA we will not reach this line!    
    			WriteDetails(classA1);
    			WriteDetails(classA2);
    
    			classA1.Name = "Updated";
    			classA2.Name = "Updated";
    
    			WriteDetails(classA1);
    			WriteDetails(classA2);
    		}
    		catch(Exception ex)
    		{
    			Console.WriteLine(ex.Message);
    		}
    		System.Console.WriteLine("End of test");
    	}
    
    	static void WriteDetails(ClassA classA)
    	{
    		Console.WriteLine(String.Format("ID={0} Name={1} TypeName={2}", 
    			classA.ID, classA.Name, classA.ClassAType.Name));
    	}
    }
---
    public class ClassA
    {
    	public int ID { get; set; }
    	public string ClassATypeCode { get; set; }
    	public string Name { get; set; }
    		
    	//Navigation properties
    	public virtual ClassAType ClassAType { get; set; }
    }
    
    public class ClassAConfiguration  : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ClassA>
    	{
    	public ClassAConfiguration()
    		: this("dbo")
    	{
    	}
    
    	public ClassAConfiguration(string schema)
    	{
    		ToTable("TEST_ClassA", schema);
    		HasKey(x => x.ID);
    
    		Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
    		Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("varchar").HasMaxLength(50);
    		Property(x => x.ClassATypeCode).HasColumnName(@"ClassATypeCode").IsRequired().HasColumnType("varchar").HasMaxLength(50);
    
    		//HasRequired(a => a.ClassAType).WithMany(b => b.ClassAs).HasForeignKey(c => c.ClassATypeCode);
    		HasRequired(a => a.ClassAType).WithMany().HasForeignKey(b=>b.ClassATypeCode);
    	}
    }

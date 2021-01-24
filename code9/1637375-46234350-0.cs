    public class ParentModel
    	{
    		public int Id { get; set; }
    		public ChildModel ChildModel { get; set; }
    	}
    
    	public class ChildModel
    	{
    		[ForeignKey("ParentModel")]
    		[Key]
    		public int ParentModelID { get; set; }
    		public ParentModel ParentModel { get; set; }
    	}
    
    	public class Context : DbContext
    	{
    		public DbSet<ParentModel> ParentModels { get; set; }
    		public DbSet<ChildModel> ChildModels { get; set; }
    
    		protected override void OnModelCreating(DbModelBuilder modelBuilder)
    		{
    			// Configure ParentModel & ChildModel entity
    			modelBuilder.Entity<ParentModel>()
    				.HasOptional(s => s.ChildModel) // Mark ChildModel property optional in ParentModel entity
    				.WithRequired(ad => ad.ParentModel); // mark ParentModel property as required in ChildModel entity. Cannot save ChildModel without ParentModel
    		}
    	}

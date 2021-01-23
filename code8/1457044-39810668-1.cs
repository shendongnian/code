    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")            
        {
            
        }
		//Add your Model objects here, You can copy them from automatically generated DbContext
        public virtual DbSet<ModelObjectName> PropertyName { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			//Copy the modelBuilder configuration here from automatically generated DbContext here
                     
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ChildModel
    {
        public int Id { get; set; }
        public ParentModel ParentModel { get; set; }
    }
    public class ParentModel
    {
        //[ForeignKey("ChildModel")]
        //[Key]
        public int ChildModelId { get; set; }
        public ChildModel ChildModel { get; set; }
    }
    public class Context : DbContext
    {
        public DbSet<ChildModel> ChildModels { get; set; }
        public DbSet<ParentModel> ParentModels { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentModel>().HasKey(s => s.ChildModelId);
            modelBuilder.Entity<ParentModel>().HasRequired(s => s.ChildModel).WithOptional(s => s.ParentModel);
        }
    }

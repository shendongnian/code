    public class ExampleContext: DbContext
    {
        public ExampleContext() : base("ExampleContext") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Data");
            ///...
        }

    public class Parent : MyValueObject
    {
        public string Name { get;set; }
    }
    public class MyValueObject
    {
        public int Id { get;set; }
        public int SSN { get;set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parent>().Property(new { p.Id, p.SSN}).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        base.OnModelCreating(modelBuilder);
    } 

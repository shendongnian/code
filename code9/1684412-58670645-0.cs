public class SampleContext:DBContext{
public DbSet<WorkUser> WorkUsers{ get; set; }
protected override void OnModelCreating(ModelBuilder modelBuilder){
    modelBuilder.Entity<WorkUser>()
        .Property(p => p.WorkUserId )
        .ValueGeneratedOnAdd();
 }
}

 c-sharp
internal class AZSQLDbContext : DbContext
{
    public AZSQLDbContext() {
        this.Database.EnsureCreated();
    }
    internal DbSet<TaskExecutionInformation> TaskExecutionInformation { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbUser = "your-user";
        var dbPW = "your-pw";
        optionsBuilder.UseSqlServer(
            $"Server=tcp:sample-sql.database.windows.net,1433;Initial Catalog=sample-db;Persist Security Info=False;User ID={dbUser};Password={dbPW};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}
TaskExecutionInformation is just a PoCo and could be anything. See below though if you need a bit of guidance.
 c-sharp
public class TaskExecutionInformation
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public int Duration { get; set; }
}

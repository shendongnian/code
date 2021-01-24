    public interface IFileSystem {
        string[] ReadAllLines(string path);
    }
    public class FileWrapper : IFileSystem {
        public string[] ReadAllLines(string path) {
            var lines = File.ReadAllLines(path);
            return lines;
        }
    }
    public interface IProjectContext : IDisposable {
        DbSet<Operator> Operators { get; set; }
        int SaveChanges();
        //...add other functionality that needs to be exposed as needed
        //eg: Database Database { get; }
        //...
    }
    public class MyProjectContext : DbContext, IProjectContext {
        public MyProjectContext(DbContextOptions<MyProjectContext> options) : base(options) { }
        public DbSet<Operator> Operators { get; set; }
    }

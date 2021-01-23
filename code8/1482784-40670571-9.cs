    public interface IContext : IDisposable {
    
        public DbSet<Toy> Toys { get; }
        
        //...other properties and methods
    }
    public class Context : DbContext, IContext {
        public Context() { ... }
        public DbSet<Toy> Toys { get; set; }
        //...other properties and methods
    }

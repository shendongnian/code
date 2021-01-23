    public interface IContext {
        DbSet<Blog> Blogs { get; set; } 
    }
    public class Context : DbContext, IContext { 
        public virtual DbSet<Blog> Blogs { get; set; } 
    } 

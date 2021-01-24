    public class ToDoContext : DbContext
    {
        public ToDoContext() // this is a parameterless (with no parameters) constructor 
        { }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        { }
        public DbSet<ToDo> ToDos { get; set; }
    }

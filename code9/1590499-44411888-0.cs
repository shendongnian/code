    public class MovieDBContext : DbContext
    {
        public MovieDBContext () : base("Name=MovieDBContext")
        {
        }
        public DbSet<Movie> Movies { get; set; }    
    }

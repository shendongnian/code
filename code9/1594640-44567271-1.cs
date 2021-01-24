    public class Game
    {
        public int GameId {get; set;}
        public virtual ICollection<Genre> Genres {get; set;}
        ... // other properties
    }
    public class Genre
    {
        public int GenreId {get; set;
        public virtual ICollection<Game> Games {get; set;}
        ...
    }
    public MyDbContext : DbContext
    {
        public DbSet<Game> Games {get; set;}
        public DbSet<Genre> Genres {get; set;}
        ...
    }

     public interface ISongRepository
    {
        IEnumerable<Song> List(ISpecification<Song> specification);
        //IQueryable<Song> List();
        Song GetById(int id);
        void Add(Song song);
        IEnumerable<string> AllArtists();
        IEnumerable<Genre> AllGenres();
    }

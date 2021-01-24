    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int GroupId { get; set; }
        public string Genre { get; set; }
    }
    public  class Repository
    {
        private List<Movie> localDb;
        public Repository()
        {
            localDb = new List<Movie>();
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            localDb = new List<Movie>();
            var movie1 = new Movie() { Title = "Movie1", Year = 2000, GroupId = 1, Genre = "Action" };
            var movie2 = new Movie() { Title = "Movie2", Year = 1999, GroupId = 1, Genre = "Drama" };
            var movie3 = new Movie() { Title = "Movie3", Year = 2000, GroupId = 1, Genre = "Comedy" };
            var movie4 = new Movie() { Title = "Movie4", Year = 2000, GroupId = 2, Genre = "Action" };
            var movie5 = new Movie() { Title = "Movie5", Year = 1999, GroupId = 2, Genre = "Drama" };
            var movie6 = new Movie() { Title = "Movie6", Year = 1999, GroupId = 2, Genre = "Drama" };
            var movie7 = new Movie() { Title = "Movie7", Year = 1999, GroupId = 2, Genre = "Horror" };
            localDb.Add(movie1);
            localDb.Add(movie2);
            localDb.Add(movie3);
            localDb.Add(movie4);
            localDb.Add(movie5);
            localDb.Add(movie6);
            localDb.Add(movie7);
            return localDb;
        }
    }
    public  class Library
    {
        private IEnumerable<Movie> MoviesLibrary;
        public Library(IEnumerable<Movie> movies)
        {
            this.MoviesLibrary = movies.ToList();
        }
        public Library GetByYear(int year)
        {
            return new Library(this.MoviesLibrary.Where(movie => movie.Year == year));
        }
        public Library GetById(int id)
        {
            return new Library(this.MoviesLibrary.Where(movie => movie.GroupId == id));
        }
        public IEnumerable<Movie> GetByGenre(string genre)
        {
            return this.MoviesLibrary.Where(movie => movie.Genre == genre);
        }
        public void Display()			
        {
		
            foreach (var movie in this.MoviesLibrary)
            {
				Console.WriteLine("Title: {0} , Year {1}, Group: {2}, Genre: {3}", movie.Title,movie.Year,movie.GroupId, movie.Genre);
            }
        }
    }

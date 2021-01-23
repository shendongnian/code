        public class MovieRepository {
            public List<Movie> GetMoviesFromRepository()
            {
                var movies = new List<Movie>();
                var movie1 = new Movie();
                movie1.MovieID = 1;
                movie1.Title = "Terminator";
                movie1.Genre = "Comedy";
                movie1.Year = 1984;
                movie1.Country = "America";
                movie1.Picture = "http://vignette4.wikia.nocookie.net/tvdatabase/images/8/89/Terminator_(1984).jpg";
                movies.Add(movie1);
 
                var movie2 = new Movie();
                movie2.MovieID = 2;
                movie2.Title = "Terminator 2: Judgement Day";
                movie2.Genre = "Romantic";
                movie2.Year = 1991;
                movie2.Country = "America";
                movie2.Picture = "https://upload.wikimedia.org/wikipedia/en/8/85/Terminator2poster.jpg";
                movies.Add(movie2);
                return movies;
            }
        }

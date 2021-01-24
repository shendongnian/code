        public class Movie : IEnumerable<TimeSpan>
        {
            public Movie(string name, IReadOnlyList<TimeSpan> runTimes)
            {
                this.Name = name;
                this.RunTimes = runTimes;
            }
            public string Name { get; }
            public IReadOnlyList<TimeSpan> RunTimes { get; }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public IEnumerator<TimeSpan> GetEnumerator()
            {
                return RunTimes.GetEnumerator();
            }
            public override string ToString()
            {
                return "[Movie] " + Name;
            }
            public static Movie Parse(JProperty data)
            {
                var name = data.Name;
                var runTimes = new List<TimeSpan>();
                foreach (var child in data.Values())
                {
                    runTimes.Add(TimeSpan.Parse(child.Value<string>()));
                }
                return new Movie(name, runTimes);
            }
        }
        public class MovieCollectionDate : IEnumerable<Movie>
        {
            public MovieCollectionDate(DateTime date, IReadOnlyList<Movie> movies)
            {
                this.Date = date;
                this.Movies = movies;
            }
            public DateTime Date { get; }
            public IReadOnlyList<Movie> Movies { get; }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public IEnumerator<Movie> GetEnumerator()
            {
                return this.Movies.GetEnumerator();
            }
            public override string ToString()
            {
                return "[Date] " + Date + " - " + Movies.Count + " show(s)";
            }
            public static MovieCollectionDate Parse(JProperty data)
            {
                var date = DateTime.Parse(data.Name);
                var movies = new List<Movie>();
                foreach (var upperChild in data.Children<JObject>())
                {
                    foreach (var child in upperChild.Children())
                    {
                        movies.Add(Movie.Parse(child as JProperty));
                    }
                }
                return new MovieCollectionDate(date, movies);
            }
        }
        public class MovieTheatre : IEnumerable<MovieCollectionDate>
        {
            public MovieTheatre(string name, IReadOnlyList<MovieCollectionDate> dateAndMovies)
            {
                this.Name = name;
                this.DateAndMovies = dateAndMovies;
            }
            public string Name { get; }
            public IReadOnlyList<MovieCollectionDate> DateAndMovies { get; }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public IEnumerator<MovieCollectionDate> GetEnumerator()
            {
                return this.DateAndMovies.GetEnumerator();
            }
            public override string ToString()
            {
                return "[Theatre] " + Name + " - " + DateAndMovies.Count + " open day(s)";
            }
            public static MovieTheatre Parse(JProperty data)
            {
                var name = data.Name;
                var movieCollectionDates = new List<MovieCollectionDate>();
                foreach (var upperChild in data.Children<JObject>())
                {
                    foreach (var child in upperChild.Children())
                    {
                        movieCollectionDates.Add(MovieCollectionDate.Parse(child as JProperty));
                    }
                }
                return new MovieTheatre(name, movieCollectionDates);
            }
        }
        public class MovieTheatreCollection : IEnumerable<MovieTheatre>
        {
            public MovieTheatreCollection(IReadOnlyList<MovieTheatre> movieTheatres)
            {
                this.MovieTheatres = movieTheatres;
            }
            public IReadOnlyList<MovieTheatre> MovieTheatres { get; }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public IEnumerator<MovieTheatre> GetEnumerator()
            {
                return this.MovieTheatres.GetEnumerator();
            }
            public override string ToString()
            {
                return "MovieTheatreCollection: Containing " + MovieTheatres.Count + " movie theatre(s)";
            }
            public static MovieTheatreCollection Parse(JObject data)
            {
                var theatres = new List<MovieTheatre>();
                foreach (var child in data.Children().Cast<JProperty>())
                {
                    theatres.Add(MovieTheatre.Parse(child));
                }
                return new MovieTheatreCollection(theatres);
            }
        }

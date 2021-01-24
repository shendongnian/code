    public class Movie
    {
        public Movie() 
        {
        }
        public Movie(string title, int year) 
        {
            this.Title = title;
            this.Year = year;
        }
        public string Title;
        public int Year;
        public override String ToString()
        {
            return $"{Title} ({Year})";
        }
    }
    //  ...snip...
    var films = new List<Movie>();
    var hero = new Movie("Hero", 1990);
    films.Add(hero);
    //  Similar syntax for the same thing:
    films.Add(new Movie("Titanic", 1997));
    foreach (var film in films)
    {
        //  This will call Movie.ToString() to "convert" film to a string. 
        Console.WriteLine(film);
    }

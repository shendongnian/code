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
        public void Print()
        {
            Console.Write(Title);
            Console.Write(" (");
            Console.Write(Year);
            Console.Write(")\n");
        }
    }
    //  ...snip...
    var films = new List<Movie>();
    var hero = new Movie("Hero", 1990);
    films.Add(hero);
    //  Similar syntax for the same thing:
    fiilms.Add(new Movie("Titanic", 1997));

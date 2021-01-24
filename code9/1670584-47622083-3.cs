    public class Movie
    {
        public String Title { get; private set; }
        public Int32 Year { get; private set; }
        public Movie(String title, Int32 year)
        {
            Title = title;
            Year = year;
        }
        public override String ToString()
        {
            return (title + " (" + year.ToString() + ")");
        }
    }

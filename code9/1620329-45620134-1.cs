    public class Movie
    {
        public MultiLanguageString Title { get; set; }
    }
    var movie = new Movie
    {
        Title = new MultiLanguageString
        {
            { "en-CA", "Eternal Sunshine of the Spotless Mind" },
            { "fr-CA", "Du soleil plein la tête" }
        }
    };
    
    var englishTitle = movie.Title["en-CA"];

    public static void Main()
    {
        String[] titles = new String[] { "Hero", "Titanic", "Mission Impossible" };
        Int32 years = new String[] { 1990, 1997, 1996 };
        for (Int32 i = 0; i < 3; ++i)
        {
            Movie movie = new movies_t(titles[i], years[i]);
            Console.WriteLine(movie.ToString());
        }
    }

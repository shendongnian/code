    public static void Main()
    {
        Movie[] movies = new Movie[]
        {
            new Movie("Hero", 1990),
            new Movie("Titanic", 1997),
            new Movie("Mission Impossible", 1996),
        };
        for (Int32 i = 0; i < movies.Length; ++i)
            Console.WriteLine(movies[i].ToString());
    }

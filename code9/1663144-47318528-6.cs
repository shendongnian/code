    static void Main(string[] args)
    {
        IEnumerable<Movie> movies = GetMoviesAsync().GetAwaiter().GetResult();
        Console.WriteLine($"Retrieved {movies.Count()} movies.");
    }

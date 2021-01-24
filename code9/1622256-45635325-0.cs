    public ICollection<string> GetDistinctCategory()
    {
        ICollection<Movie_Class> movies = GetMovies();
        return movies.SelectMany(x => x.Category.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            .Select(x => x.Trim())
            .Distinct()
            .ToList();
    }

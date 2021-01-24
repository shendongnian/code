    public async Task<int> CountMovies(List<string> pGenres)
    {
        return await (
            from movie in Context.Movie
            join genre in Context.MovieGenre on movie.MovieId equals genre.MovieId into genres
            where pGenres.All(pGenre => genres.Any(genre => genre.GenreName == pGenre))
            select movie.Id
        ).CountAsync();
    }

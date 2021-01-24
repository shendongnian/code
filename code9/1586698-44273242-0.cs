    public async Task<int> CountMovies(List<string> pGenres) {
        return await (
            from movie in Context.Movie
            join genre in Context.MovieGenre on movie.MovieId equals genre.MovieId into genres
            where genres.Where(genre => pGenres.Contains(genre.GenreName)).Count() == pGenres.Count()
            select movie
        ).CountAsync();
    }

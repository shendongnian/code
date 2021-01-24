            public async Task<int> CountMovies(List<string> pGenres, int? year, decimal? minPrice,
            decimal? maxPrice)
        {
            using (var command = Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"SELECT COUNT(DISTINCT Movie.movie_id) from Movie_Genre join Movie on Movie.movie_id = Movie_Genre.movie_id where genre_name in ('Action', 'Adult')";
                Context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    await result.ReadAsync();
                    int amount = result.GetInt32(0);
                    Context.Database.CloseConnection();
                    return amount;
                }
            }
        }

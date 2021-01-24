    public IEnumerable<MovieModel> FindMatchedMovieModels(List<string> names)
    {
        var matchedMovieModels = from movieModel in db.MovieModels
                                 join name in names
                                 where movieModel.Name equals name
                                 select movieModel;
        return matchedMovieModels;
    }

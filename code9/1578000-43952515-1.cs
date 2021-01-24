    public static ListModel CreateLists(string name, DateTime date, List<string> names)
    {
        var matchedMovieModels = from movieModel in db.MovieModels
                                 join name in names
                                 on movieModel.Name equals name
                                 select movieModel;
        return new ListModel
        {
            ListName = name,
            DateOfCreation = date.Date,
            MoviesList = new ObservableCollection<MovieModel>(matchedMovieModels)
        };
    }

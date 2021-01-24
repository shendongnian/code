    var movies = from m in db.Movies
                 select m;
    if (!string.IsNullOrEmpty(movieGenre))
    {
        movies = movies.Where(x => x.Genre == movieGenre);
    }
    return View(movies);

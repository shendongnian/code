    public ActionResult Create( NewMovieViewModel movie)
    {
        if (ModelState.IsValid)
        {
            db.Movies.Add(movie.movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(movie);
    }

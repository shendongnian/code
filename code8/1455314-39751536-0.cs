    [HttpGet("movies/{title}")]
    public ActionResult Movie(string title)
    {
        // Recreate list here... or store it somewhere and query against it in the below line
        Movie movie = movieList.Single(x => x.Title == title);
        if (movie == null)
        {
            return HttpNotFound();
        }
        return View(movie);
    }

    public ActionResult Index(int? genreid)
    {
        if (genreid.HasValue)
        {
            // return songs based on the passed genreid to the view
            return View(m.TrackGetByGenre(genreid.Value));
        }
        // return all songs to the view
        return View(m.TrackGetAll());
    }

    public ActionResult Index(int? genreid)
    {
        if (genreid.HasValue && genreid.Value == 9)
        {
            // return all pop songs to the view
            return View(m.TrackGetAllPop());
        }
        // return all songs to the view
        return View(m.TrackGetAll());
    }

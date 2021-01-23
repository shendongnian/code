    if (String.IsNullOrEmpty(SearchTitle)) {
      return View("Error");
    }
    var db = new CinemaContext();
    var Movie = (from m in db.Movie
                Where m.Title.Contains(SearchTitle)
                select new {
                 Id = m.MovieID,
                 Title = m.Title // can add more properties
                }).ToList();
    return Json(Movie, JsonRequestBehavior.AllowGet);

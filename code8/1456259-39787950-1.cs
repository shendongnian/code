    public ActionResult Details(Guid? id)
    {
            
        Review review = db.Reviews.Find(id);
        ViewBag.RatingList = new SelectList(Enumerable.Range(1, 10));
            
        return View(review);
    }

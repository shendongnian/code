     public ActionResult CreateRate(RateReview rate)
        {
            if (ModelState.IsValid)
            {
                rate.Id = Guid.NewGuid();
                db.RateReviews.Add(rate);
                db.SaveChanges();
                return RedirectToAction("Details", "Reviews", new { id = rate.ReviewId });
            }
            return View();
        }

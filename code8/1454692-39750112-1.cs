        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "Id,UserId,ReviewId,Comment,CreatedDate")] CommentToReview commentToReview)
        {
            if (ModelState.IsValid)
            {
                commentToReview.Id = Guid.NewGuid();
                commentToReview.UserId = Session["LoggedUserID"].ToString();
                commentToReview.CreatedDate = DateTime.Now;
                db.CommentToReviews.Add(commentToReview);
                db.SaveChanges();
                return RedirectToAction("Details", "Reviews", new { id = commentToReview.ReviewId });
            }
            return RedirectToAction("Details", "Reviews", new { id = commentToReview.ReviewId });
        }

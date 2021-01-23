    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,UserId,ReviewId,Comment,CreatedDate")] CommentToReview commentToReview)
    {
        if (ModelState.IsValid)
        {
            //the code to add the comment
    
            return Json(new
            {
                success = true,
                //other data for the comment, maybe the rendered comment as html to display it on the view.
            });
        }
    
        ViewBag.ReviewId = new SelectList(db.Reviews, "Id", "Title", commentToReview.ReviewId);
        ViewBag.UserId = new SelectList(db.Users, "Id", "Username", commentToReview.UserId);
        return View(commentToReview);
    }

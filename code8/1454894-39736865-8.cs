    [HttpPost]
    public ActionResult CreateComment(CommentReviewVm model)
    {
      if(ModelState.IsValid)
      {
         var m = new CommentReview { Comment = model.Comment, ReviewId=model.ReviewId };
         m.userID = new Guid(Session["LoggedUserID"].ToString());       
         m.CreatedDate = DateTime.Now;
         db.CommentToReviews.Add(m);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
      return View(model);
    } 

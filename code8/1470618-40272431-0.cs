    public ActionResult Create(Guid reviewId)
    {
        var newComment = new CommentToReview
        {
            UserId = UserId,
            ReviewId = reviewId
        };
    
        return PartialView("_CommentPartial", newComment); //return the partial from the action
    }

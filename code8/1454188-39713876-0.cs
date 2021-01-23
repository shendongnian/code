    public ActionResult MyComments(Guid? id)
    {
    	id = Guid.Parse(Session["LoggedUserID"].ToString());
    
    	var review = db.Comments.Where(m => m.CreatorUserId.Equals(id));
    	var result = review.ToList(); 
    	
    	return View(result);
    }

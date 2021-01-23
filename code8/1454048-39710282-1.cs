    [HttpPost]
    public ActionResult Create(Review review)
    {  
        if (ModelState.IsValid) 
        {
            if(Session["LoggedUserID"]==null)
            {
               return Content("Session LoggedUserID is empty");
            }
            review.UserID = Convert.ToInt32(Session["LoggedUserID"]);   
            db.Reviews.Add(review);
            db.SaveChanges();
    
            return RedirectToAction("Index");
        }
        return View(review);        
    }

            [HttpPost]
            public ActionResult MyReviews(FormCollection formCollection)
            {    
                string[] ids = formCollection["chkReviewId"].Split(new char[] {','});
    
                foreach (var id in ids)
                {
                    var review = db.Reviews.Find(Guid.Parse(id));
                    db.Reviews.Remove(review);
                    db.SaveChanges();
                }    
                 
                var description = db.Reviews.Where(m => m.Id == new Guid(Session["LoggedUserId"].ToString()));    
                return View(description.ToList());      
            }

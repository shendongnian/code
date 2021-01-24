    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Title,Body")] Post post)
    {
    	if (ModelState.IsValid)
    	{
    		var userId = User.Identity.GetUserId();
    		post.ApplicationUserId = userId;
    		db.Posts.Add(post);
    		db.SaveChanges();
    		return RedirectToAction("Index");
    	}
    
    	return View(post);
    }

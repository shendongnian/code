    public ActionResult Comments()
    {
        var comm = db.Article.Include(x=>x.Comments).ToList(); 
        // This will get All article and include comments if any for each article.
        return View("Comments", comm.ToList());
    }

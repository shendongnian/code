    public ActionResult Index(string Sid)
    {
        var grad = db.Gradings.Include(g => g.Activity).Include(g => g.Student).Where(g => g.StudentID == Sid).ToList();  
    
        return View(grad);    
    }

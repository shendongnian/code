    [HttpPost]
    public ActionResult Create(Projet model)
    {
       var exist = db.Projects.Any(s=>s.SeqNumber===model.SeqNumber 
                                    && s.ProjectId!=model.ProjectId);
       if(exist)
       {
         ModelState.AddModelError(string.empty,"Sequence number is already in use");
        return View(model);
       }
       // to do : Continue with your save
    }

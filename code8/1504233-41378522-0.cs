    using System; //lib that allow you to use DateTime
    ...
    
    [HttpPost][ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "pkID,projectID,languageID,projectCompany,projectTitle,projectLink,projectText,projectImageURL,isPassive,createDateTime,createUsername,updateDateTime,updateUsername")] cusContentProjects cusContentProjects)
    {
        if (ModelState.IsValid)
        {
            db.cusContentProjects.Add(cusContentProjects);
            var date = DateTime.now; //save it wherever you need
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(cusContentProjects);
    }

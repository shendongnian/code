    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "AutomobilID,Marka,Model,Godiste,
              Zapremina_motora,Snaga,Gorivo,Karoserija,Opis,Cena,Kontakt")] Automobil automobil, 
                                               HttpPostedFileBase productImg)
    {
        if (ModelState.IsValid)
        {
            if(productImg!=null)
            {
              var fileName = Path.GetFileName(productImg.FileName);
              var directoryToSave = Server.MapPath(Url.Content("~/Pictures"));
       
               var pathToSave = Path.Combine(directoryToSave, fileName);
               productImg.SaveAs(pathToSave);
               automobil.Fotografija= fileName;
            } 
           
            db.Automobils.Add(automobil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(automobil);
    }

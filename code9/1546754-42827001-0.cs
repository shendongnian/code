    public ActionResult Create(Image image, HttpPostedFileBase ImageID)
        {
    
    var sp = db.Images.OrderBy(c=>c.Order).ToList(); // sort with Order
     if (ModelState.IsValid)
            {
                 db.Images.Add(image);
                 db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            return View(sp);
    
    }

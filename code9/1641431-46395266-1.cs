    [HttpPost]
    public ActionResult Create(string country)
        {
         if (ModelState.IsValid)//if theres not errors
            {
               //Add your save Funcation Here
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();//if there is errors display the same view
        }

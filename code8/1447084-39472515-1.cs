    [Authorize(Roles = "Administrator")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Car car)
    {
        if (ModelState.IsValid)
        {
          if (car.File.ContentLength > 0)
          {
             var fileName = Path.GetFileName(car.File.FileName);
             var path = Path.Combine(Server.MapPath("~/Images/Cars"), fileName);
             picture.File.SaveAs(path);
             car.Photo = fileName;
          }
          db.Cars.Add(car);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
        return View(car);
    }

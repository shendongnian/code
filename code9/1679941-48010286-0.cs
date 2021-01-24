    public ActionResult reviewPreevent(int? id)
    {
        id = 100;
        if (id.HasValue)
        {
            using(formEntities db = new formEntities()) {
                var form = (from a in db.form_preevent
                    select new preeventForm
                    {
                        id = a.id,
                        meeting = a.meeting,
                        date = (DateTime)a.eventDate,
                        location = a.location,
                        p1Foyer = (bool)a.p1Foyer,
                        .
                        .
                        .
                        income = (float) a.income
                    }).Where(t => t.id == id).FirstOrDefault();
                return View(form);  //THIS LINE MODIFIED
            }
        }else
        {
            TempData["notice"] = "No form with ID: " + id + " was found.";
            return View();
        }
    }

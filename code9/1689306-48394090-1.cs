    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var property = db.Properties.Find(id);
        if (property == null)
        {
            return HttpNotFound();
        }
        PropertySimilar pros = new PropertySimilar();
        pros.CurrentProperty = property;
        pros.Properties = db.Properties.ToList();
        return View(pros);
    }

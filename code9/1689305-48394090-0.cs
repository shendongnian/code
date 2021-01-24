    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (property == null)
            {
                return HttpNotFound();
            }
            PropertySimilar pros = new PropertySimilar();
            pros.CurrentProperty = db.Properties.Find(id);
            pros.Properties = db.Properties.ToList();
            return View(pros);
        }

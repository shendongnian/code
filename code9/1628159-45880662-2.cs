    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    
        data data = db.data.Find(id);
        if (data == null)
        {
            return HttpNotFound();
        }
        var groupedData = db.data.Where(d => d.truckID == data.truckID).ToList();
        
        return View(groupedData);
    }

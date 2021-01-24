    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    
        var orderMaster = db.OrderMasters
            .Where(om => om.OrderMasterId == id)
            .Include(om => om.OrderDetails); // include the details here
            .Single();
        return View(orderMaster);
    }

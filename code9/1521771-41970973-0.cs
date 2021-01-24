        public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        CheckOut checkOut = db.CheckOut
            .Include(c => c.CheckOutStatus)
            .Include(c => c.DwgList)
            .SingleOrDefault(x => x.CheckId == id);
                        
        if (checkOut == null)
        {
            return HttpNotFound();
        }
                    
        return View(checkOut);
    }

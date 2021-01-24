    [HttpPost]
    public ActionResult Edit(Tool tool):
        tool.Holder = db.MobileUsers.Single(x => x.Name == tool.HolderName);
        if (ModelState.IsValid)
        {
            db.Entry(tool).State = EntityState.Modified;
            db.Entry(tool.Holder).State = EntityState.Modified;  // Need to set child state as well
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(tool);
    }

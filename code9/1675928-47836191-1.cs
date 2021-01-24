    [HttpPost]
    public ActionResult Edit(Tool tool):
        if (ModelState.IsValid)
        {
            // If you want to update fields in tool.Holder, do something like this:
            var newHolder = tool.Holder;  // save changes from view.
            // Fetch the current Holder from database
            tool.Holder = db.MobileUsers.Single(x => x.Name == tool.HolderName);
            // Replace the changed properties. Many ways to do this. I like Automapper.
            tool.Holder.Field1 = newHolder.Field1;
            tool.Holder.Field2 = newHolder.Field2;
            // etc.
            db.Entry(tool).State = EntityState.Modified;
            // Below not needed since you getched it into the context
            // db.Entry(tool.Holder).State = EntityState.Modified;  // Need to set child state as well
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(tool);
    }

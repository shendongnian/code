    public ActionResult FullDetails(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Menu menu = db.Menus.Include(r => r.MenuGroups).FirstOrDefault(r => r.Id == id);
        if (menu == null)
        {
            return HttpNotFound();
        }
        return View(menu);
    }

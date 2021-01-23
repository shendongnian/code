    public ActionResult FullDetails(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Menu menu = db.Menus.Find(id);
        if (menu == null)
        {
            return HttpNotFound();
        }
        return View(menu);
    }

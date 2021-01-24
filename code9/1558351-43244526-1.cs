    public ActionResult Edit(int? id)
    {
        if (!CheckAccess())
        {
            return RedirectToAction("Index", "Error");
        }
        .....
    }

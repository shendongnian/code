    [HttpPost]
    public ActionResult Add(BOL1.tbl_NIR nir)
    {
            if (ModelState.IsValid)
            {
                db.tbl_NIR.Add(nir);
                db.SaveChanges();
                Session["id"]=nir.ID;
                return RedirectToAction("AddIO");
            }
        return View(nir);
    }

    [HttpPost]
    public ActionResult Add(BOL1.tbl_NIR nir)
    {
            if (ModelState.IsValid)
            {
                db.tbl_NIR.Add(nir);
                db.SaveChanges();
                //~~~~~~~~~~~~
                var nirID= db.tbl_NIR.OrderByDescending(x => x.ID).FirstOrDefault().ID;
                TempData["id"]= nirID;
                //~~~~~~~~~~
                return RedirectToAction("AddIO");
            }
        return View(nir);
    }

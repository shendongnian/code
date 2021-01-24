    [HttpGet]
    public ActionResult AddIO()
    {
       //var ni = db.tbl_I_O.OrderByDescending(x => x.NirID).FirstOrDefault().NirID;
       //return View(ni);
       return PartialView(new BOL1.tbl_I_O());
    }

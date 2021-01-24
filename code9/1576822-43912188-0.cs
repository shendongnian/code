    public ActionResult Index()
    {
        var parts = _db.Goods.Include("Descriptions").Where(x=>x.good_id == id);
        return View(parts));
    }

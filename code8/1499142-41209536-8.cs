    public ActionResult Index()
    {
        var data = db.ModelA
                       .Include(c => c.ModelB)
                       .Select(x=>new MyViewModel { AId = x.AId,
                                                    Total = x.ModelBs.Sum(z=>z.RequestAmount) })
                       .ToList();
        return View(data);
    } 

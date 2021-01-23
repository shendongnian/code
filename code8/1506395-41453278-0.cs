    // GET: Destination
    [HttpGet]
    public async Task<ActionResult> IndexVM()
    {
        var model = new BeerIndexVM();
    
        using (var db = new AngularDemoContext())
        {
            model.Beers = await db.Beers.ToListAsync();
        }
        return Json(model, JsonRequestBehavior.AllowGet);
    }

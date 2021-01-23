    [VisitCount]
    [OutputCache]
    public async Task<ActionResult> Index()
    {
        return View(await db.Departments.ToListAsync());
    }

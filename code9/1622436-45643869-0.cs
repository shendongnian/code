    public ActionResult Create()
    {
        ViewBag.Companies = _context.Companies.ToList();
        return View();
    }

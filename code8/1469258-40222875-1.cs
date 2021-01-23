    // GET: Database/Details/00000000-0000-0000-0000-000000000000
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null || subscription == null)
        {
            return NotFound();
        }
        var model = new IndexViewModel();
        model.Country = await _context.countries.SingleOrDefaultAsync(s => s.Id == id);
        model.Cities = SomeFunction();
        return View(model);
    }

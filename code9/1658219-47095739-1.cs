    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Make,Model,Color,licensePlate")] Cars cars)
    {
        if (ModelState.IsValid)
        { 
            cars.DateTimeStamp = DateTime.Now;
            _context.Add(cars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cars);
    }

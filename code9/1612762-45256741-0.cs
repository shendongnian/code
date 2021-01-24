    public async Task<JsonResult> Stats()
    {
    Champion champion = await _context.Champions
        .Include(c => c.BaseStats)
        .FirstOrDefaultAsync();
        return Json(champion);
    }

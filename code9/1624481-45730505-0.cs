    public async Task<ActionResult> Details(int? id)
    {
        var user = await _context.User
                    .Include(k => k.Contact)
                    .Include(k => k.Contact.Select(c => c.ContactType))
                    .SingleOrDefaultAsync(m => m.Id == id);
        return View(user);
    }

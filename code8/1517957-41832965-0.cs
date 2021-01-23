    if (ModelState.IsValid)
    {
        string currentUserId = User.Identity.GetUserId();
        employer.User = _context.Users.FirstOrDefault(u => u.Id == currentUserId);
        _context.Add(employer);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

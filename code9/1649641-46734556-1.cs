    _context.Update(manager);
    if (manager.Password == null)
    {
        _context.Entry(manager).Property(x => x.Password).IsModified = false;
    }
    await _context.SaveChangesAsync();

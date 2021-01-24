    public IActionResult DeletePart (string partType, int id)
    {
        Type type = GetTypeOfPart(partType);
        var part = _context.Find(type, id);
        var entry = _context.Entry(part);
        entry.State = EntityState.Deleted;
        _context.SaveChanges();
        
    }

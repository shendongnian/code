    public SomeEntity AddOrUpdate(SomeEntity item)
    {
        var original = _context.SomeDbSet.Local.FirstOrDefault(p => p.Id == item.Id) 
                       ?? _context.SomeDbSet.FirstOrDefault(p => p.Id == item.Id);
        if (original != null) // Updating
        {
            var entry = _context.Entry(original);
            entry.CurrentValues.SetValues(item);
        }
        else
        {
             // New item
             item = _context.SomeDbSet.Add(item);
        }
        return item;
    }

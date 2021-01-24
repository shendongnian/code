    // This looks horrible 
    //_context.Note.Where(x => x.Order == oldIdx).First().Order = newIdx - 1;
    
    // ahh.. my eyes
    var note = _context.Note.Where(x => x.Order == oldIdx).FirstOrDefault();
    // sanity check
    if(Note == null)
    {
        return;
    }
    note.Order = newIdx - 1;
    // save it back to the DB
    _context.SaveChanges();
    // get your new awesome ordered list
    var list = _context.Note.OrderBy(x => x.Order).ToList(); 

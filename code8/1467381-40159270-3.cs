    var terms = search_string.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    IQueryable<Attributes> att = db.AttributesTable;
    foreach(var term in terms)
    {
        att = att.Where(x => x.Description.Contains(term));
    }
    
    return View(att.ToList());

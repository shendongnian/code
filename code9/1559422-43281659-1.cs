    IQueryable<x> query = (from x in db.TABLE....
      join y in db.TABLE...);
    if (search.anno != null)
    {
      query = query.Where(x => x.ANNO == search.anno);
    }   
      
    if (search.Cliente != null)
    {
      query = query.WHere(x => x.CODICE_CLIENTE == search.Cliente);
    }
    var model = query.ToList();  // or await query.ToListAsync();

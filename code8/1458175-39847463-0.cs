    //filteredQuery is an IQueryable<ICB_TRANSACTION>
    var filteredQuery = DbContext.Set<ICB_TRANSACTION>();
    
    if (_input.i_Type != -99) // -99 = All type
        filteredQuery = filteredQuery.Where(x => x.TYPE == _input.i_Type);
    
    if (_input.i_Member_ID != null && _input.i_Member_ID > 0)
        filteredQuery = filteredQuery.Where(x => x.CREATE_BY_ID == _input.i_Member_ID);
    
    //now we have done the filters, let's do the order by / take part.
    //sortedQuery is an IOrderedQueryable<ICB_TRANSACTION>
    var sortedQuery = _input.b_OderByDesc 
         ? filteredQuery.OrderByDescending(x => x.ID)
         : filteredQuery.OrderBy(x => x.ID);
    
    if (_input.i_Top > 0)
        sortedQuery = sortedQueryable .Take(_input.i_Top);
    
    return sortedQuery.ToList();

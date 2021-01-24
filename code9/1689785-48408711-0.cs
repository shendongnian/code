    var query = from a in db.AGREEMENTS select a;
    query = query.Where(a => a.something == mandatoryParamter);
    if(optionalParameter1 != null)
    {
        query = query.Where(a => a.something == optionalParameter1);
    }
    if(optionalParameter2 != null)
    {
        query = query.Where(a => a.something == optionalParameter2);
    }

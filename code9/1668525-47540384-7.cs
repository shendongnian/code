    List<int> k = new List<int>();  //Assuming SalesStatusID's type is int32
    if (filter != null)
    {
        k.Add(filter.Value);
    }
    else
    {
        k = _db.SalesStatus.Select(a=>a.SaleStatusID).ToList();
    }
    // use k now

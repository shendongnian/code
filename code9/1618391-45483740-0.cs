    Products = (
    from d in db.PODetails
    join p in db.Products on d.ProductID equals p.ProductID
    join palloc in db.POAllocations on d.PODetailID equals palloc.PODetailID
    group by new { 
        PODetailID = d.PODetailID,         
        Sku = p.Sku,
        Cntnr20 = p.Cntnr20,
        Cntnr40 = p.Cntnr40,
        Cntnr40HQ = p.Cntnr40HQ }
    into grp
    where grp.Key.POID == id
    select new PODetailsFull
    {
        PODetailID = grp.Key.PODetailID,
        QtyRegion = grp,                 
        Sku = grp.Key.Sku,
        Cntnr20 = grp.Key.Cntnr20 ?? 0,
        Cntnr40 = grp.Key.Cntnr40 ?? 0,
        Cntnr40HQ = grp.Key.Cntnr40HQ ?? 0
    }).ToList();

    var groupedSupplier = supplier.GroupBy(s => new { s.Supplier, s.Product })
                                  .Select(supplier => supplier.Supplier, 
                                                      supplier.Product,
                                                      supplier.Price1 = string.Join(",", supplier.Select(x => x.Price1)),
                                                      supplier.Price2 = string.Join(",", supplier.Select(x => x.Price2)),
    ...);

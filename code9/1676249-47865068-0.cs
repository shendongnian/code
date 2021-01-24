    Customer c = null;
    Receipt r = null;
    SoldProduct sP = null;
    Product p = null;
    var queryOver = Session.QueryOver(() => c)
        .JoinAlias(() => c.Receipts, () => r)
        .JoinAlias(() => r.SoldProducts, () => sP)
        .JoinAlias(() => sp.Product, () => p)
        .Where(() => c.Name.IsLike(query.Search, MatchMode.Anywhere) ||
                               c.Surname.IsLike(query.Search, MatchMode.Anywhere) ||
                               c.Address.IsLike(query.Search, MatchMode.Anywhere) ||
                               p.OldId.ToString().IsLike(query.Search, MatchMode.Anywhere))

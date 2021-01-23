    ISQLQuery query = session.CreateSQLQuery(sqlQueryStr);
    return query.SetResultTransformer(new CustomTransformer())
                .List<UniqueCustomerPurchase>()
                .GroupBy(cp => cp.CustomerName)
                .Select(g => new KeyValuePair(g.Key, g.Select(cp => cp));

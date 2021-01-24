    var result = ProductList1.Except(productlist3).Union(ProductList2)
        .GroupBy(e => new { K1 = e.UniqueGroupId, K2 = e.UniqueGroupId == null ? e.Id : null }) // (1)
        .OrderBy(g => g.Key.K1).ThenBy(g => g.Key.K2) // (2)
        .Skip(...).Take(...) // 3
        .SelectMany(g => g) // 4
        .GroupBy(e => e.UniqueGroupId); // 5

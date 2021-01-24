    var groupedResults = results.GroupBy(a => new { 
        a.Item1.FieldOne, 
        a.Item1.FieldTwo, 
        a.Item2.FieldThree}
    ).Select(g => new {
        g.Key.FieldOne,
        g.Key.FieldTwo,
        g.Key.FieldThree,
        Price = g.Sum(x => x.Price),
        Quantity = g.Sum(x => x.Quantity)
    });

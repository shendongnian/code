    var first = list.First().Amount;
    Enumerable.Range(0, list.Count)
        .Aggregate((c, n) =>
        {
            list[c].Amount = list[n].Amount;
            return n;
        });
    list.Last().Amount = first;

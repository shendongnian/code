    var orderedByAsc = list.OrderBy(l => l.name);
    if (list.SequenceEqual(orderedByAsc))
    {
          ascending = true;
    }
    var orderedByDsc = list.OrderByDescending(l => l.name);
    if (list.SequenceEqual(orderedByDsc))
    {
          ascending = false;
    }

    var groups = DATALIST.GroupBy(ComputeLimit);
    // using .Skip(1).Any() instead of .Count() because it is faster
    // to determ if the group has exactly one item
    // NOTE: If there is more then one group having exactly one item
    // the result will be the group with the lowest limit
    // also the ordering may be OK for you, if you need to keep the result consisted
    var bestBalanced = groups
             .Where(x => x.Skip(1).Any() == false)
             .OrderBy(x => x.Key)
             .First()
             .Single()

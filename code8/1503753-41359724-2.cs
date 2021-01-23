    List<string> R = new List<string>();
    while (R.Count > 0)
    {
        var removing = new ConcurrentBag<long>();
        var N = new ConcurrentBag<string>();
        var first = R[0];
        N.Add(first);
        R.Remove(first);
        Parallel.ForEach(R, (item, state, index) =>
        {
            if(hamming(first, item))
            {
                removing.Add(index); // remember the indexes, later we remove these indexes from R
                N.Add(item);
            }
        });
        
        // now we are safe to remove items.
        int deleted = 0;
        foreach (var index in removing.OrderBy(index => index))
        {
            R.RemoveAt((int)index - deleted);
            deleted++;
        }
        
        // get other stuff...
    }

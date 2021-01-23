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
                N.Add(item);
                R[(int)index] = null; // mark as null and ignore. 
                                      // this is not thread safe for versioning of list but doesn't matter.
                                      // for R ConcurrentBag can be used too but it doesn't change results after all.
            }
        });
        
        // now we are safe to reorganize our collection.
        R = R.Where(str => str != null).ToList(); // parallel execution doesn't help. see comments below. 
                                                  // for very large collection this will finish in few milliseconds.
        
        // get other stuff...
    }

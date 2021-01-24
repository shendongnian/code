    // If no EqualityComparer is provided, use the default one:
    cmp = cmp ?? EqualityComparer<TKey>.Default;
    // create the two lookup tables:
    ILookup<TKey, TA> alookup = sourceA.ToLookup(keySelectorA, cmp);
    ILookup<TKey, TB> blookup = sourceB.ToLookup(keySelectorB, cmp);
    // get a collection of all keys used in sourceA and/or sourceB.
    // Remove duplicates using the equalityComparer
    IEnumerable<TKey> allKeysUsedInA = sourceA.Select(a => keySelectorA(a));
    IEnumerable<TKey> allKeysUsedInB = sourceB.Select(b => keySelectorB(b));
    IEnumerable<TKey> allUsedKeys = allKeysUsedInA
        .Concat(allKeysUsedInB)
        .Distinct(cmp);
    // now enumerate over all keys, get the matching elements from sourceA / sourceB 
    // use defaults if not available
    foreach (TKey key in allUsedKeys)
    {
        // get all A elements with TKey, use the default value if the key is not found
        IEnumerable<TA> foundAs = alookup[key].DefaultIfEmpty(defaultA);
        foreach (TA foundA in foundAs)
        {
            // get all B elements with TKey, use the default value if the key is not found
            IEnumerable<TB> foundBs = blookup[key].DefaultIfEmpty(defaultB);
            foreach (TB foundB in foundBs)
            {
                TResult result = resultSelector(foundA, foundB, key);
                yield return result;
            }
        }
    }

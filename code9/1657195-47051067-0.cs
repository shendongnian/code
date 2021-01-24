    IEnumerable<TResult> FullOuterJoin(IEnumerable<T1> table1, IEnumerable<T2> table2)
    {
        // put table1 elements in a dictionary with Id as key
        // do the same for table2 elements
        Dictionary<int, T1> lookup1 = table1.ToDictionary(t1 => t1.Id);
        Dictionary<int, T2> lookup2 = table2.ToDictionary(t2 => t2.Id);
        // create a sequence of all Ids used in table1 and/or table2
        // remove duplicates using Distinct
        IEnumerable<int> allIdsInT1 = table1.Select(t1 => t1.Id);
        IEnumerable<int> allIdsInT2 = table2.Select(t2 => t2.Id);
        IEnumerable<int> allUsedIds = allIdsInT1
            .Concat(allIdsInT2)
            .Distinct();
        // now enumerate over all elements in allUsedIds.
        // find the matching element in lookup1
        // find the matching element in lookup2
        // if no match found: use null
        foreach (int id in allUsedIds)
        {
            // find the element with Id in lookup1; use null if there is no such element
            T1 found1;
            bool t1Found = lookup1.TryGetValue(id, out found1);
            if (!t1Found) found1 = null;
            // find the element with Id in lookup2; use null if there is no such element
            T2 found2;
            bool t2Found = lookup2.TryGetValue(id, out found2
            if (!t2Found) found2 = null;
            TResult result = new TResult()
            {
                Id = id,
                Table1Value = found1,
                Table2Value = found2,
            };
            yield return result;
        }

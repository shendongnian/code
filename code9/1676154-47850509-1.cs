    public static IEnumerable<Tuple<TA, TB> EqualityZip<TA, TB, TKey>(
        this IEnumerable<TA> sourceA,   // the first sequence
        this IEnumerable<TB> sourceB,   // the second sequence
        Func<TA, TKey> keySelectorA,    // the property of sourceA to take
        Func<TB, TKey> keySelectorB,    // the property of sourceB to take
        IEqualityComparer<TKey> comparer)
    {
        // TODO: ArgumentNullException if arguments null
        if (comparer==null) comparer = EqualityCompare<TKey>.Default;
         var enumeratorA = sourceA.GetEnumerator();
            var enumeratorB = sourceB.GetEnumerator();
            
            // enumerate as long as we have elements in A and in B:
            bool aAvailable = enumeratorA.MoveNext();
            bool bAvailable = enumeratorB.MoveNext();
            while (aAvailable && bAvailable)
            {   // we have an A element and a B element
                TKey keyA = keySelectorA(enumeratorA.Current);
                TKey keyB = keySelectorB(enumeratorB.Current);
                if (comparer.Equals(keyA, keyB)
                {
                    yield return Tuple.Create(Ta, Tb)
                }
                else

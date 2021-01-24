    public static IEnumerable<TResult> FullOuterJoin<TA, TB, TKey, TResult>(
       IEnumerable<TA> sourceA,       // The first collection
       IEnumerable<TB> sourceB,       // The second collection
       Func<TA, TKey> keySelectorA,   //which property from A is the key to join on?
       Func<TB, TKey> keySelectorB,   //which property from B is the key to join on?
       Funct<TA, TB, TKey, TResult> resultSelector,
       // says what to return with the matching elements and the key
       TA defaultA = default(TA),     // use this value if no matching A is found
       TA defaultB = default(TB),     // use this value if no matching B is found
       IEqualityComparer<TKey> cmp = null)
       // the equality comparer used to check if key A equals key B)
      {
          // TODO implement
      }

    public static IObservable<T> DistinctFor<T>(this IObservable<T> src, 
                                                TimeSpan validityPeriod)
    {
        //if HashSet<DistinctForItem<T>> actually allowed us the get at the 
        //items it contains it would be a better choice. 
        //However it doesn't, so we resort to 
        //Dictionary<DistinctForItem<T>, DistinctForItem<T>> instead.
        var hs = new Dictionary<DistinctForItem<T>, DistinctForItem<T>>();
        return src.Select(item => new DistinctForItem<T>(item)).Where(df =>
        {
            DistinctForItem<T> hsVal;
            if (hs.TryGetValue(df, out hsVal))
            {
                var age = DateTime.UtcNow - hsVal.Created;
                if (age < validityPeriod)
                {
                    return false;
                }
            }
            hs[df] = df;
            return true;
        }).Select(df => df.Item);
    }

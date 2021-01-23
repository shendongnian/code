    public static IEnumerable<RecommenderItem> Merge(IEnumerable<Restaurant> restaurants, IEnumerable<Dish> dishes)
    {
        using (var r = restaurants.GetEnumerator())
        using (var d = dishes.GetEnumerator())
        {
            while (r.MoveNext() && d.MoveNext())
            {
                yield return new RecommenderItem {Id = r.Current.Id, Entity = r.Current};
                yield return new RecommenderItem {Id = d.Current.Id, Entity = d.Current};
            }
        }
    }

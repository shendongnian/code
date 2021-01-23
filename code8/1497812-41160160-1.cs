    public static IEnumerable<RecommenderItem> Merge(IEnumerable<Restaurant> restaurants, IEnumerable<Dish> dishes)
    {
        using (var r = restaurants.GetEnumerator())
        using (var d = dishes.GetEnumerator())
        {
            while (true)
            {
                bool rAvailable = r.MoveNext();
                bool dAvailable = d.MoveNext();
                if (rAvailable)
                    yield return new RecommenderItem { Id = r.Current.Id, Entity = r.Current };
                if (dAvailable)
                    yield return new RecommenderItem { Id = d.Current.Id, Entity = d.Current };
                if (!rAvailable && !dAvailable)
                    break;
            }
        }
    }

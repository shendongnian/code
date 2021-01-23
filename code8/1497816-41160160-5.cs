    public static IEnumerable<RecommenderItem> Merge(IEnumerable<Restaurant> restaurants, IEnumerable<Dish> dishes)
    {
        foreach (var item in restaurants.ZipLongest(dishes, (r, d) => new { r, d }))
        {
            if (item.r != null)
                yield return new RecommenderItem { Id = item.r.Id, Entity = item.r };
            if (item.d != null)
                yield return new RecommenderItem { Id = item.d.Id, Entity = item.d };
        }
    }

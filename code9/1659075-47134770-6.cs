    public CakeInfo GetCakeInfo()
    {
        var detailsList = ...;
        var baked = detailsList.Where(where_part_baked).Select(x=>x.Week).GroupBy(x=>x.Week)
           .Select(x=>new Tuple<int, int>(x.Key, x.Count()));
        var sold = detailsList.Where(where_part_sold).Select(x=>x.Week).GroupBy(x=>x.Week)
           .Select(x=>new Tuple<int, int>(x.Key, x.Count()));
        var burnt = detailsList.Where(where_part_burnt).Select(x=>x.Week).GroupBy(x=>x.Week)
           .Select(x=>new Tuple<int, int>(x.Key, x.Count()));
        return new CakeInfo(baked, sold, burnt);
    }

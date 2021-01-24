    var ID = (from item in ConflictDatas.AsEnumerable()
    group item by new
    {
     ID = item.Field<string>("ID"),
     DesignArticle = item.Field<string>("DesignArticle"),
     DesignNo = item.Field<string>("DesignNo"),
     PatternCode = item.Field<string>("PatternCode")
     } into g
     where g.Count() >= 2
     select new
      {
         g.Key.ID
         }).Select(x => x.ID).ToList();

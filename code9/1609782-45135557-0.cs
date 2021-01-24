    var ID = from item in ConflictDatas.AsEnumerable()
                                 group item by new
                     {
                         ID = item.Field<int>("ID"),
                         DesignArticle = item.Field<string>("DesignArticle"),
                         DesignNo = item.Field<string>("DesignNo"),
                         PatternCode = item.Field<string>("PatternCode")
                     } into g
                                 where g.Count() > 2
                                 select new
                                  {
                                      ID = g.Key.ID
                                  };

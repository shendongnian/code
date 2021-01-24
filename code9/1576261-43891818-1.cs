    var q9i = from view in tv.test_views                                // FROM test_view
              group view by new { view.LastName, view.AutoName } into g // GROUP BY LastName, AutoName
              select new { g.Key.AutoName, g.Key.LastName,              // SELECT AutoName, LastName
                           Count = g.Where(x => x.Type != null).Count() }; // COUNT(Type)
    var q9 = q9i.ToList();

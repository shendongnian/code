    List<Tuple<int, int>> excercisesWithTime = new List<Tuple<int, int>>
    {
        Tuple.Create(291, 5),
        Tuple.Create(301, 5),
        Tuple.Create(291, 5)
    };
    // method syntax
    var result = excercisesWithTime.GroupBy(key => key, item => 1)
                                   .Select(group => new { 
                                       group.Key, 
                                       Duplicates = group.Count() 
                                   });
    //query syntax
    var result = from item in excercisesWithTime
                 group 1 by item into g
                 select new {
                     g.Key,
                     Duplicates = g.Count()
                 };

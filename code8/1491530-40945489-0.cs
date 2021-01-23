    var result = myList.GroupBy(x => new { x.RoomType, x.Available })
                        .Select(g => new Hotel { 
                                                 OnDate = g.First().OnDate, 
                                                 RoomType = g.Key.RoomType, 
                                                 Available = g.Key.Available, 
                                                 RateCode = "", 
                                                 Price = 0 })
                        .ToList();

     var aggrData = listUserBadge
                   .GroupBy(badge=>new { badge.Id,badge.Month, badge.Year})
                   .Select(x=>new UserBadge {Id=x.Key.Id,
                                             Name = x.First().Name,
                                             Surname = x.First().Surname,
                                             Month = x.Key.Month,
                                             Year = x.Key.Year,
                                             Hours = x.Sum(y=>y.Hours)});

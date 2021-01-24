    var result = from ul in userLeagues
                 group ul by new { ul.Country.CountryId, ul.Country.Common_Name } into g
                 select new Map.Country
                 {
                     id = g.Key.CountryId,
                     name = g.Key.Common_Name,
                     leagues = g.Select(x => new Map.League
                     {
                         id = x.LeagueID,
                         name = x.leagueNameEN,
                     })
                 };

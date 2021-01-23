    var start = new DateTime(2016, 1, 1);
    var end = new DateTime(2016, 10, 1);
    var query = from labCase in db.LabCase
                where labCase.Seq != null &&
                    labCase.Date >= start &&
                    labCase.Date <= end
                group labCase by labCase.DistCode into g
                select new
                {
                    DistCode = g.Key,
                    CountId1 = g.Count(x => x.LabId == 1),
                    CountId2 = g.Count(x => x.LabId == 2),
                    CountId3 = g.Count(x => x.LabId == 3)
                };

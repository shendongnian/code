      var opps = (from o in Entities.Table1.AsEnumerable()
                        join oa in Entities.Table2 on o.Id equals oa.Table1Id
                        where (o.StatusId == 1)
                        && oa.UserId == userId
                        select new
                        {
                            ID = o.Id,
                            Options = Entities.GetOptions(o.Id),
                            LastUpdated = o.UpdatedDate
                        }).ToList();

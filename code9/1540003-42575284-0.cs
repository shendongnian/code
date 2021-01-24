    using (var db = new LocalDbContext())
                {
    
                    var result = from p in DateRange.GetDates(new DateTime(2017, 01, 01), new DateTime(2017, 01, 20))
                                 join n in db.MyDatas.Where(x => x.EDate != null) on p.Date equals n.EDate.Value.Date into g
                                 from x in g.DefaultIfEmpty()
                                 select new
                                 {
                                     date = p,
                                     amount = x == null ? 0 : x.EAmount
                                 };
    
                    var xx = result.ToList();
                }

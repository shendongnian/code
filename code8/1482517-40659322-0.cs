    var duplicateBatchIDList = (from c in _db.TimeSheetHeaders
                                                   group c by c.BatchID into grp
                                                   where grp.Count() > 1
                                                   select new
                                                   {
                                                       BatchID = grp.FirstOrDefault().BatchID,                                                      
                                                       TimeSheetCreationDate = grp.Min(x => x.TimeSheetCreationDate >= DateTime.Now)
                                                   }).ToList();

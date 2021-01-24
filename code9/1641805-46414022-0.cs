    var serialCount = 1;
    lstDetails = (from d in db.SalesDetails
                                      join i in db.Items on d.ItemId equals i.IID
                                      join u in db.Generals on d.UoM equals u.IID
                                      select new SalelsDetailListViewModel
                                                                           {
                                          SerialNo = serialCount++,
                                          Id = d.IID,
                                          ItemId = i.IID,
                                          ItemName = i.Item1,
                                          UoM = u.IID,
                                          UnitName = u.Value,
                                          Qty = d.Qty,
                                          Disc = d.Disc
                                      }).ToList();

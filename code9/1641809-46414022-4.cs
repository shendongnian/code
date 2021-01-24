        var lstDetails = (from d in salesDetailsList
                      join i in itemList on d.ItemId equals i.IID
                      join u in generalList on d.UoM equals u.IID
                      select new
                      {
                          Id = d.IID,
                          ItemId = i.IID,
                          ItemName = i.Item1,
                          UoM = u.IID,
                          UnitName = u.Value,
                          Qty = d.Qty,
                          Disc = d.Disc
                      });
        var withSerialNo = lstDetails.Select((s, index) => new SalelsDetailListViewModel()
        {
            SerialNo = index,
            Id = s.Id,
            ItemId = s.ItemId,
            ItemName = s.ItemName,
            UoM = s.UoM,
            UnitName = s.UnitName,
            Qty = s.Qty,
            Disc = s.Disc
        }).ToList();

     var Getdetails = (from p in XYZDb.tblPulls
                          join
                          ro in XYZDb.tblRentalOrders
                          on p.AffCode equals ro.AffCode.Value
                          join
                          tpsb in XYZDb.tblPullSheetBatchProcessings
                          on p.PullNo.ToString() equals tpsb.PullSheet into pt
                          from batch in pt.DefaultIfEmpty()
                          select new
                          {
                              PullNos = p.PullNo,
                              AffCode = p.AffCode,
                              TotalItems = p.TotalItems,
                              p.PostedOn,
                              p.UpdatedOn,
                              p.IsPrinted,
                              BatchName = (batch == null ? String.Empty : batch.BatchName ) 
                          })
                          .Where(i => i.PostedOn >= from_date && i.PostedOn <= to && i.IsPrinted != null).Distinct();

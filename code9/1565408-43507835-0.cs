    var RMA_stops_all = (from rma in rDb.DistributionStopInformations
                         join line in rDb.DistributionLineItems on rma.UniqueIdNo equals line.UniqueIdNo
                         where line.RmaNumber != null 
                         &&
                         (line.DatetimeCreated > Convert.ToDateTime(dateToCheck_rma) &&
                         line.DatetimeCreated < Convert.ToDateTime(dateToCheck_rma).AddDays(7))
                         && rma.CustomerNo == TNGCustNo
                         select new
                         {
                             dtCreated = line.DatetimeCreated,
                             rma.UniqueIdNo,
                             line.RmaNumber,
                             line.RmaOriginalUniqueId,
                             line.ItemSequenceNo,
                             line.ItemNumber,
                             goodRMA_flag =  line.RmaNumber.Contains("/078"),
                         }).AsEnumerable().Select(r => new {
                             r.dtCreated,
                             r.UniqueIdNo,
                             r.RmaNumber,
                             r.RmaOriginalUniqueId,
                             r.ItemSequenceNo,
                             r.ItemNumber,
                             r.goodRMA_flag,
                             rmaGood = r.RmaNumber.Split(new string[] { "/" }, StringSplitOptions.None)[1]
                         });

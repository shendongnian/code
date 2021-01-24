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
                             UniqueIdNo = rma.UniqueIdNo,
                             RmaNumber = line.RmaNumber,
                             RmaOriginalUniqueId = line.RmaOriginalUniqueId,
                             ItemSequenceNo = line.ItemSequenceNo,
                             ItemNumber = line.ItemNumber,
                             goodRMA_flag =  line.RmaNumber.Contains("/078"),
                             rmaGood = line.RmaNumber.Substring(line.RmaNumber.IndexOf("/")+1)
                         }).ToArray();

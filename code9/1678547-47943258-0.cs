    var currentStatus = (from c in db.FL_CourierDetail
        join s in db.FL_CourierStatus
            on c.Courier equals s.CourierId
        where c.AWBNumber == awb
        select new CurrentStatus  { awb = c.AWBNumber, staus = s.StatusId, updated = s.StatusId, remark = s.Remark }).ToList();
    public class CurrentStatus
    {
        public string awb { get; set; }
        public int staus { get; set; }
        public int updated { get; set; }
        public string remark { get; set; }
    }

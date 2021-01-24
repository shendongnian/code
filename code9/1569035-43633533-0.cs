    public class BookingInfo : BookingBase
    {
    }
    public class BookingTransaction : BookingBase
    {
        public virtual string CustomerRefNo { get; set; }
    }

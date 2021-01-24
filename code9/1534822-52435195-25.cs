    public class UpsShipper : IShipper
    {
        private readonly Common.Logging.ILog logger;
        public static readonly string FriendlyName = typeof(UpsShipper).FullName; /* here for my "trick" */
        public UpsShipper(Common.Logging.ILog lgr)
        {
            if (null == lgr)
            {
                throw new ArgumentOutOfRangeException("Log is null");
            }
            this.logger = lgr;
        }
        public string FriendlyNameInstance => FriendlyName; /* here for my "trick" */
        public void ShipOrder(Order ord)
        {
            this.logger.Info("I'm shipping the Order with Ups");
        }
    }
..
    public class UspsShipper : IShipper
    {
        private readonly Common.Logging.ILog logger;
        public static readonly string FriendlyName = typeof(UspsShipper).FullName; /* here for my "trick" */
        public UspsShipper(Common.Logging.ILog lgr)
        {
            if (null == lgr)
            {
                throw new ArgumentOutOfRangeException("Log is null");
            }
            this.logger = lgr;
        }
        public string FriendlyNameInstance => FriendlyName; /* here for my "trick" */
        public void ShipOrder(Order ord)
        {
            this.logger.Info("I'm shipping the Order with Usps");
        }
    }

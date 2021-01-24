    public class BorrowedItemModel
        {
        public String _id { get; set; }
        public String issuer { get; set; }
        public String issued { get; set; }
        public String issuedname { get; set; }
        public String obj { get; set; }
        private String _date;
        public String date 
        { get {return _date;} 
          set 
          {
            _date=value;
            dateTime = DateTime.Parse(value);
            timeleft = dateTime - DateTime.UtcNow;
          }
        }
        private DateTime dateTime { get; set; }
        private TimeSpan timeleft { get; set; }
        public string TimeLeftString { get; set; }
        private Timer timer;
        public BorrowedItemModel()
        {
            timer = new Timer(1000*60);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            //dateTime = DateTime.Parse(date);
            //timeleft = dateTime - DateTime.UtcNow;
        }
    }

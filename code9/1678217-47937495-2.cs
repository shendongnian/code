    public class MovingDate : log4net.Appender.RollingFileAppender.IDateTime
    {
	    public DateTime CurrentDateTime = DateTime.Now;
       
        public DateTime Now
        {
            get
            {
                return CurrentDateTime;
            }
        }
	}

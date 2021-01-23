        private static readonly DateTime POSIXRoot = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public static double GetPosixSeconds(DateTime value)
        {
            return (value - POSIXRoot).TotalSeconds;
        }
	    public static DateTime GetDateTime(double posixSeconds) {
	        return POSIXRoot.AddSeconds(posixSeconds);
	    }

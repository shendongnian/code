    static Regex myTimePattern = new Regex(@"(\d{1,2}):(\d{1,2}):(\d{1,2})");
    static TimeSpan DurationTimespan( string s )
    {
            if ( s == null ) throw new ArgumentNullException("s");
            Match m = myTimePattern.Match(s);
            if ( ! m.Success ) throw new ArgumentOutOfRangeException("s");
            string hh = m.Groups[1].Value;
            string mm = m.Groups[2].Value;
    
            int hours   = int.Parse( hh );
            int minutes = int.Parse( mm );
            if ( minutes < 0 || minutes > 59 ) throw new ArgumentOutOfRangeException("s");
            TimeSpan value = new TimeSpan(hours , minutes , 0 );
            return value ;
        }

    class PayPeriod
    {
        const int DAYS_PER_WEEK = 7;
        const int WEEKS_PER_PERIOD = 4;
        static readonly DateTime _startPeriod = new DateTime( 2017, 01, 01 );
        public PayPeriod( int index )
        {
            Index = index;
            StartDate = _startPeriod.Date.AddDays( ( index - 1 ) * DAYS_PER_WEEK * WEEKS_PER_PERIOD );
            EndDate = StartDate.AddDays( DAYS_PER_WEEK * WEEKS_PER_PERIOD - 1 );
        }
        public static PayPeriod FromDate( DateTime date )
        {
            var index = ( date.Date - _startPeriod ).Days / DAYS_PER_WEEK / WEEKS_PER_PERIOD + 1;
            return new PayPeriod( index );
        }
        public int Index { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }

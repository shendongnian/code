    public struct YearMonth
    {
        public readonly int Year;
        public readonly int Month;
    
        public YearMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }
    
        public override string ToString()
        {
            return Year + "-" + Month;
        }
    }

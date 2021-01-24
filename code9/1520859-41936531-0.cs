    public static class MyDayHelper
    {
        public static bool IsWeekDay(DayOfWeek myday)
        {
            return myday >= DayOfWeek.Monday && myday <= DayOfWeek.Friday;
        }
        public static bool IsWeekEnd(DayOfWeek myday)
        {
            return myday == DayOfWeek.Saturday || myday == DayOfWeek.Sunday;
        }
        public static string ReturnWeekdays()
        {
            return string.Format("{0},{1},{2},{3},{4}", DayOfWeek.Monday, DayOfWeek.Tuesday,
                DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday);
        }
        public static string SunTilFri
        {
            get
            {
                return string.Format("{0},{1},{2},{3},{4},{5}", DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday);
            }
        }
    }

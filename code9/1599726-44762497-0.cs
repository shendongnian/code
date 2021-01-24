    public class Report
    {
        public int SundayAvg { get; set; }
        public int MondayAvg { get; set; }
        public int TuesdayAvg { get; set; }
       
        //new property that just returns Todays average. 
        public int TodayAverage => GetTodayAverage();
    
    
        public int GetTodayAverage()
        {
            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return SundayAvg;
                case DayOfWeek.Monday:
                    return MondayAvg;
                case DayOfWeek.Tuesday:
                    return TuesdayAvg;
                 ...
                default:
                    //How the hell did that happen;
                    return 0;
                 
            }
        }
    }

    public class HolidayDataAccess : IHolidayDataAccess
    {
        private readonly IHolidayDataContext holDataContext;
    
        public HolidayDataAccess(IHolidayDataContext holDataContext)
        {
            this.holDataContext = holDataContext;
        }
       
        public IEnumerable<HolidayDate> GetHolidayDates(DateTime startDate, DateTime endDate)
        {
            using (this.holDataContext)
            {
                IList<HolidayDate> dates = holDataContext.Dates.FromSql($"[dba].[usp_GetHolidayDates] @StartDate = {startDate}, @EndDate = {endDate}").ToList();
                return dates;
            }
        }
    }

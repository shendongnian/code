    public class HolidayDataAccess : IHolidayDataAccess
    {
        private readonly IHolidayDataContext holDataContext;
    
        public HolidayDataAccess(IHolidayDataContext holDataContext)
        {
            this.holDataContext = holDataContext;
        }
       
        public async Task<IEnumerable<HolidayDate>> GetHolidayDates(DateTime startDate, DateTime endDate)
        {
            using (this.holDataContext)
            {
                IList<HolidayDate> dates = await holDataContext.Dates.FromSql($"[dba].[usp_GetHolidayDates] @StartDate = {startDate}, @EndDate = {endDate}").AsNoTracking().ToListAsync();
                return dates;
            }
        }
    }

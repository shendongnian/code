    public class ReChronoDB : DbContext
    {
        public DbSet<ReWeekRowModel> WeekRows { get; set; }    
        public DbSet<ReDayModel> DayRows { get; set; }    
    }

    public interface ISerialize
    {
        void Serialize();
    }
    public class SSRS_Subscription : ISerialize
    {
        [Key]
        public Guid id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Recurrence RecurrencePattern { get; set; }
        public int? MinuteInterval { get; set; }
        public int? DaysInterval { get; set; }
        public int? WeeksInterval { get; set; }
        [NotMapped]
        public DaysOfWeek DaysOfWeek { get; set; }
        [Column("DaysOfWeek")]
        private string internalDaysOfWeek { get; set; }
        [NotMapped]
        public MonthsOfYear MonthsOfYear { get; set; }
        [Column("MonthsOfYear")]
        private string internalMonthsOfYear { get; set; }
        public Catalog_Reports_Subscription()
        {
            DaysOfWeek = new DaysOfWeek();
            MonthsOfYear = new MonthsOfYear();
        }
        public WhichWeek? MonthWhichWeek { get; set; }  
        public string Days { get; set; }
        public void Serialize()
        {
            internalDaysOfWeek = SerializeHelper.SerializeJson(DaysOfWeek);
            internalMonthsOfYear = SerializeHelper.SerializeJson(MonthsOfYear);
        }
        public class Configuration : EntityTypeConfiguration<SSRS_Subscription>
        {
            public Configuration()
            {
                Property(s => s.internalDaysOfWeek).HasColumnName("DaysOfWeek");
                Property(s => s.internalMonthsOfYear).HasColumnName("MonthsOfYear");
            }
        }
    }
